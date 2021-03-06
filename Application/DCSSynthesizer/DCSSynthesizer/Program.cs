﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using DCSArchiveClientApi;
using DtbSynthesizerLibrary;
using DtbSynthesizerLibrary.Daisy202;
using Mono.Options;
using Directory = System.IO.Directory;
using Nota.NLogExtention;

namespace DCSSynthesizer
{
    class Program
    {

        private static string GetTitleNumber(string c, int y, int n)
        {
            if (String.IsNullOrEmpty(c))
            {
                return null;
            }
            if (Regex.IsMatch(c, @"^UNI\d$", RegexOptions.IgnoreCase))
            {
                return (Int32.Parse(c.Substring(4)) + n).ToString();
            }
            if (Regex.IsMatch(c, @"^UN\d\d$", RegexOptions.IgnoreCase))
            {
                return (Int32.Parse(c.Substring(3)) + n).ToString();
            }
            return $"{c}{y:D4}{n:D4}";
        }

        private static int GetIsoWeekNumber(DateTime date)
        {
            if (new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday }.Contains(date.DayOfWeek))
            {
                date = date.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
        }

        private static string sourceCode = null;
        private static string destCode = null;
        private static string sourceTitleNumber = null;
        private static string destTitleNumber = null;
        private static int year = DateTime.Now.Year;
        private static int? number;
        private static bool useDate = false;
        private static int bitrate = 32;
        private static string uncRoot = @"\\smb-files\Temp\DCSSynthesizer";
        private static string dcsServiceUri = "http://http-dcsarchive";
        private static string defaultCreator = "Nota";
        private static bool forceOverwriteDCS = false;
        private static bool useDCSPro = false;
        private static bool noCleanupOfTemp = false;
        private static bool skipUploadToArchive = false;
        private static ClientApi clientApi = null;

        private static string DestPath => Path.Combine(uncRoot, destTitleNumber);

        private static readonly OptionSet Options = new OptionSet()
            .Add("Synthesize DTB from DCS")
            .Add("sourcecode=", "Source code", s => sourceCode = s)
            .Add("destcode=", "Destination code", s => destCode = s)
            .Add("sourcetitleno=", "Source title number", s => sourceTitleNumber = s)
            .Add("desttitleno=", "Destination title number", s => destTitleNumber = s)
            .Add("uncroot=", "UNC path to temporarily store generated DTB", s => uncRoot = s)
            .Add("dcsuri=", "DCS Archive Service Base Uri", s => dcsServiceUri = s)
            .Add<int>("year=", "Year", i => year = i)
            .Add<int>("number=", "Number", i => number = i)
            .Add<int>("bitrate=", "BitRate (default is 48)", i => bitrate = i)
            .Add("usedate", "Use date for default number (mmdd), otherwise the iso week number of the next following saturday is used",
                s => useDate = s != null)
            .Add("force", "Force overwriting destination DTB in DCS", s => forceOverwriteDCS = s != null)
            .Add("nocleanup", "Prevents cleanup of temp files, can be used for debug", s => noCleanupOfTemp = s != null)
            .Add("skipupload", "Create output but skips upload to arch. Can be used for debug", s => skipUploadToArchive = s != null)
            .Add("usedcspro", "Use smb-dcspro in place of smb-dcsweb", s => useDCSPro = s != null);

        // Get a logger
        private static NotaLogger logger = NotaLogManager.GetCurrentClassLogger(null, "DCSSynthesizer");

        private static string OptionDescriptions
        {
            get
            {
                var wr = new StringWriter();
                Options.WriteOptionDescriptions(wr);
                return wr.GetStringBuilder().ToString();
            }
        }
        static int Main(string[] args)
        {
            try
            {
                var unhandledArgs = Options.Parse(args);
                if (unhandledArgs.Any())
                {
                    throw new OptionException($"Unhandled arguments {unhandledArgs.Aggregate((s, v) => $"{s} {v}")}", "");
                }
                if (!number.HasValue)
                {
                    number = useDate 
                        ? 100 * DateTime.Now.Month + DateTime.Now.Day 
                        : GetIsoWeekNumber(Enumerable
                            .Range(1, 7)
                            .Select(i => DateTime.Today.AddDays(i))
                            .Single(d => d.DayOfWeek == DayOfWeek.Saturday));
                }
                if (String.IsNullOrWhiteSpace(sourceTitleNumber))
                {
                    sourceTitleNumber = GetTitleNumber(sourceCode, year, number.Value);
                }
                if (String.IsNullOrWhiteSpace(destTitleNumber))
                {
                    destTitleNumber = GetTitleNumber(destCode, year, number.Value);
                }
                if (String.IsNullOrEmpty(sourceTitleNumber))
                {
                    throw new OptionException("No DCS source was given", "");
                }
                if (String.IsNullOrEmpty(destTitleNumber))
                {
                    throw new OptionException("No DCS destination was given", "");
                }
            }
            catch (OptionException e)
            {
                logger.Error(e, $"{e.Message}\n{OptionDescriptions}");
                return -1;
            }
            try
            {
                logger.Info($"Synthesizing {sourceTitleNumber} to {destTitleNumber}");
                clientApi = new ClientApi {BaseAddress = dcsServiceUri};
                try
                {
                    if (!clientApi.Ping().Wait(10000))//Will throw an exception, if service is not accessible
                    {
                        logger.Error($"Timeout while pinging DCS Archive api {dcsServiceUri}");
                        return -1;
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, $"Could not connect to DCS Archive api {dcsServiceUri} due to an {e.GetType()}: {e.Message}");
                    return -1;
                }
                var task = Execute();
                task.Wait();
                if (task.Result != 0)
                {
                    return task.Result;
                }
                logger.Info($"Succesfully synthesized {sourceTitleNumber} to {destTitleNumber} in DCS Archive");
                return 0;
            }
            catch (AggregateException e)
            {
                logger.Error(e, $"Unexpected exception in DCSSynthesizer");
                return -1000;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Unexpected exception in DCSSynthesizer");
                return -1000;
            }
            finally
            {
                try
                {
                    if (Directory.Exists(DestPath) && !noCleanupOfTemp)
                    {
                        Directory.Delete(DestPath, true);
                        logger.Info($"Cleaned up destination folder {DestPath}");
                    }
                    else
                    {
                        logger.Info($"Skipping clean up of destination folder {DestPath}");
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, $"Could not cleanup destination folder {DestPath} due to an unexpected {e.GetType()}: {e.Message}");
                }
            }
        }

        private static async Task<int> DownloadSource()
        {
            var title = await clientApi.GetTitle(sourceTitleNumber);
            if (title == null)
            {
                logger.Error($"Could not find source title {sourceTitleNumber} in DCS Archive");
                return -1;
            }
            if (title.MaterialType.Code != "ETXT")
            {
                logger.Error($"Source title has Material Type Code {title.MaterialType.Code}, expected ETXT");
                return -1;
            }
            if (!title.Items.ContainsKey("DTB"))
            {
                logger.Error($"Source title {sourceTitleNumber} has no DTB (Dtbook xml) item");
                return -1;
            }
            var sourceDir = title.DirectoriesAsList.Select(d => useDCSPro ? d.FullPath : d.WebFullPath).First();
            if (!Directory.Exists(sourceDir))
            {
                logger.Error($"Could not access source title at {sourceDir}");
                return -1;
            }
            CopyDirectory(sourceDir, DestPath);
            logger.Info($"Downloaded source dtbook from {sourceDir}");
            return 0;
        }

        private static async Task<int> UploadDestination()
        {
            var ncc = XDocument.Load(Path.Combine(DestPath, "ncc.html"));
            var titleUpdate = new DCSArchiveLibrary.Model.TitleUpdate
            {
                SourcePath = DestPath,
                OriginCode = "DDS",
                MaterialTypeCode = "DTB",
                MaterialFormatCode = "D202",
                TitleNo = destTitleNumber,
                Title = Utils.GetMetaContent(ncc, "dc:title"),
                Creator = Utils.GetMetaContent(ncc, "dc:creator") ?? defaultCreator,
                MetadataFromDBBDokSys = false
            };

            var existingTitle = await clientApi.GetTitle(destTitleNumber);
            if (existingTitle != null)
            {
                titleUpdate.TitleID = existingTitle.ID;
                await clientApi.UpdateTitleFormat(titleUpdate);
            }
            else
            {
                await clientApi.CreateTitle(titleUpdate);
            }
            logger.Info("Uploaded synthesized DTB to DCSArchive");
            return 0;
        }

        private static int Synthesize()
        {
            var sourceFileName = Path.Combine(DestPath, $"{sourceTitleNumber}.xml");
            if (!File.Exists(sourceFileName))
            {
                logger.Error($"Could not find source file {sourceFileName}");
                return -1;
            }
            XDocument dtbook;
            try
            {
                dtbook = XDocument.Load(sourceFileName, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            }
            catch (Exception e)
            {
                logger.Error(e, $"Could not load source file {sourceFileName}");
                return -1;
            }
            var xhtmlFileName = Path.Combine(DestPath, $"{destTitleNumber}.html");
            Utils.SetMeta(dtbook, "dc:identifier", $"dk-nota-{destTitleNumber}");
            Utils.TransformDtbookToXhtml(dtbook).Save(xhtmlFileName);
            if (File.Exists(sourceFileName))
            {
                File.Delete(sourceFileName);
            }
            var synthesizer = new Daisy202Synthesizer()
            {
                XhtmlDocument = XDocument.Load(xhtmlFileName, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo),
                EncodeMp3 = true,
                Mp3BitRate = bitrate
            };
            synthesizer.Progress += (sender, args) =>
            {
                Console.Write($"{args.ProgressPercentage:D3}% {args.ProgressMessage}".PadRight(80).Substring(0, 80) + "\r");
            };
            synthesizer.GenerateDtb();
            Console.Write($"{new String(' ', 80)}\r");
            logger.Info("Synthesized DTB");
            return 0;
        }

        private static async Task<int> Execute()
        {
            try
            {
                if (Directory.Exists(DestPath))
                {
                    Directory.Delete(DestPath, true);
                }
                Directory.CreateDirectory(DestPath);
            }
            catch (Exception e)
            {
                logger.Error(e, $"Could not create destination directory {DestPath} due to an unexpected {e.GetType()}: {e.Message}");
                return -2;
            }

            if (!forceOverwriteDCS && (await clientApi.GetTitle(destTitleNumber)) != null)
            {
                logger.Warn($"Destination title {destTitleNumber} already exists in DCS. Use -force to overwrite");
                return 0;
            }

            var res = await DownloadSource();
            if (res != 0)
            {
                return res;
            }

            res = Synthesize();
            if (res != 0)
            {
                return res;
            }

            if (!skipUploadToArchive)
            {
                return await UploadDestination();
            }
            else
            {
                logger.Info($"Skipping upload of title {destTitleNumber} to DCSArchive");
                return 0;
            }
        }

        private static void CopyDirectory(string source, string dest)
        {
            CopyDirectory(new DirectoryInfo(source), dest);
        }

        private static void CopyDirectory(DirectoryInfo source, string dest)
        {
            if (!Directory.Exists(dest))
            {
                Directory.CreateDirectory(dest);
            }
            foreach (var file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(dest, file.Name));
            }
            foreach (var dir in source.GetDirectories())
            {
                CopyDirectory(dir, Path.Combine(dest, dir.Name));
            }
        }

    }
}
