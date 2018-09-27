﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Xml.Linq;
using NAudio.Wave;

namespace DtbSynthesizerLibrary.Xml
{
    public class SystemSpeechXmlSynthesizer : IXmlSynthesizer
    {
        static SystemSpeechXmlSynthesizer()
        {
            Synthesizer = new SpeechSynthesizer();
            SynthesizerList = Synthesizer
                .GetInstalledVoices()
                .Select(v => new SystemSpeechXmlSynthesizer(v.VoiceInfo))
                .ToList();
        }

        private static readonly List<SystemSpeechXmlSynthesizer> SynthesizerList;

        public static IReadOnlyCollection<IXmlSynthesizer> Synthesizers
            => SynthesizerList.AsReadOnly();

        public static IXmlSynthesizer GetPreferedVoiceForCulture(CultureInfo ci)
        {
            return Utils.GetPrefferedXmlSynthesizerForCulture(ci, Synthesizers);

        }

        private SystemSpeechXmlSynthesizer(VoiceInfo voice)
        {
            Voice = voice;
        }

        protected static SpeechSynthesizer Synthesizer { get; }

        protected VoiceInfo Voice { get; }

        protected void AppendElementToPromptBuilder(XElement element, PromptBuilder promptBuilder, IDictionary<string, XText> bookmarks)
        {
            foreach (var node in element.Nodes())
            {
                if (node is XElement elem)
                {
                    AppendElementToPromptBuilder(elem, promptBuilder, bookmarks);
                }
                else if (node is XText text)
                {
                    var nameSuffix = bookmarks.Count.ToString("000000");
                    bookmarks.Add(nameSuffix, text);
                    promptBuilder.AppendBookmark($"B{nameSuffix}");
                    promptBuilder.AppendText(Utils.GetWhiteSpaceNormalizedText(text.Value));
                    promptBuilder.AppendBookmark($"E{nameSuffix}");
                }
            }
        }


        public TimeSpan SynthesizeElement(XElement element, WaveFileWriter writer, string src = "")
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            var startOffset = writer.TotalTime;
            var audioStream = new MemoryStream();
            Synthesizer.SetOutputToAudioStream(
                audioStream,
                new SpeechAudioFormatInfo(
                    writer.WaveFormat.SampleRate,
                    (AudioBitsPerSample)writer.WaveFormat.BitsPerSample,
                    (AudioChannel)writer.WaveFormat.Channels));
            var bookmarks = new Dictionary<string, XText>();
            //var promptBuilder = new PromptBuilder() { Culture = Voice.Culture };
            //promptBuilder.StartVoice(Voice);
            //AppendElementToPromptBuilder(element, promptBuilder, bookmarks);
            //promptBuilder.EndVoice();
            var ssmlDocument = Utils.BuildSsmlDocument(element, bookmarks);
            var bookmarkDelegate = new EventHandler<BookmarkReachedEventArgs>((s, a) =>
            {
                if (bookmarks.ContainsKey(a.Bookmark.Substring(1)))
                {
                    var text = bookmarks[a.Bookmark.Substring(1)];
                    var anno = text.Annotation<SyncAnnotation>();
                    if (anno == null)
                    {
                        anno = new SyncAnnotation { Src = src, Text = text, Element = text.Parent};
                        text.AddAnnotation(anno);
                    }
                    switch (a.Bookmark.Substring(0, 1))
                    {
                        case "B":
                            anno.ClipBegin = startOffset + a.AudioPosition;
                            break;
                        case "E":
                            anno.ClipEnd = startOffset + a.AudioPosition;
                            break;
                    }
                }
            });
            Synthesizer.BookmarkReached += bookmarkDelegate;
            try
            {
                Synthesizer.SpeakSsml(Utils.SerializeDocument(ssmlDocument));
            }
            finally
            {
                Synthesizer.BookmarkReached -= bookmarkDelegate;
            }
            Synthesizer.SetOutputToNull();
            audioStream.WriteTo(writer);
            writer.Flush();
            var annotations = element.DescendantNodes().SelectMany(n => n.Annotations<SyncAnnotation>()).ToList();
            if (annotations.Any())
            {
                annotations.First().ClipBegin = startOffset;
                for (int i = 0; i < annotations.Count - 1; i++)
                {
                     annotations[i + 1].ClipBegin = annotations[i].ClipEnd;
                }
                var lastClipEnd = annotations.Last().ClipEnd;
                if (lastClipEnd != writer.TotalTime)
                {
                    if (lastClipEnd == startOffset)
                    {
                        annotations.Last().ClipEnd = writer.TotalTime;
                    }
                    else
                    {
                        //Time seems to "slide" in bookmark events, 
                        //resulting in the last bookmark seeming located beyond the end of the audio file
                        //The factor corrects this problem (possibly in a correct manner)
                        var factor =
                            (writer.TotalTime - startOffset).TotalSeconds
                            / (lastClipEnd - startOffset).TotalSeconds;
                        foreach (var anno in annotations)
                        {
                            anno.ClipBegin = Utils.AdjustClipTime(anno.ClipBegin, startOffset, factor);
                            anno.ClipEnd = Utils.AdjustClipTime(anno.ClipEnd, startOffset, factor);
                        }
                    }
                }
            }
            return writer.TotalTime.Subtract(startOffset);
        }

        public VoiceMetaData VoiceInfo => new VoiceMetaData("System.Speech", Voice.Id)
        {
            Name = Voice.Name,
            Culture = Voice.Culture,
            Gender = Voice.Gender.ToString(),
            AdditionalInfo = new ReadOnlyDictionary<string, string>(Synthesizer.Voice.AdditionalInfo)
        };

        public int PreferedSampleRate => 
            Voice.SupportedAudioFormats.Any(f => f.SamplesPerSecond==22050) 
                ? 22050 
                : (Voice.SupportedAudioFormats.FirstOrDefault()?.SamplesPerSecond ?? 22050);
    }
}
