﻿namespace DtbMerger2MacroEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEntryUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEntryDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEntryOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEntryInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadMacroEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDTBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertDTBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateMergedDtbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.addDTBButton = new System.Windows.Forms.Button();
            this.insertDTBButton = new System.Windows.Forms.Button();
            this.saveMacro = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.macroTreeView = new System.Windows.Forms.TreeView();
            this.propertiesDataGridView = new System.Windows.Forms.DataGridView();
            this.ObjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openMacroButton = new System.Windows.Forms.Button();
            this.moveEntryUpButton = new System.Windows.Forms.Button();
            this.moveEntryOutButton = new System.Windows.Forms.Button();
            this.deleteEntryButton = new System.Windows.Forms.Button();
            this.moveEntryInButton = new System.Windows.Forms.Button();
            this.moveEntryDownButton = new System.Windows.Forms.Button();
            this.buildProgressBar = new System.Windows.Forms.ProgressBar();
            this.buildMessageLabel = new System.Windows.Forms.Label();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveDtbBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mainMenuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.actionsToolStripMenuItem});
            resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
            this.mainMenuStrip.Name = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMacroToolStripMenuItem,
            this.saveMacroToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openMacroToolStripMenuItem
            // 
            this.openMacroToolStripMenuItem.Name = "openMacroToolStripMenuItem";
            resources.ApplyResources(this.openMacroToolStripMenuItem, "openMacroToolStripMenuItem");
            this.openMacroToolStripMenuItem.Click += new System.EventHandler(this.OpenMacroClickHandler);
            // 
            // saveMacroToolStripMenuItem
            // 
            this.saveMacroToolStripMenuItem.Name = "saveMacroToolStripMenuItem";
            resources.ApplyResources(this.saveMacroToolStripMenuItem, "saveMacroToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitClickHandler);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveEntriesToolStripMenuItem,
            this.reloadMacroEntriesToolStripMenuItem,
            this.deleteEntryToolStripMenuItem,
            this.addDTBToolStripMenuItem,
            this.insertDTBToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // moveEntriesToolStripMenuItem
            // 
            this.moveEntriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveEntryUpToolStripMenuItem,
            this.moveEntryDownToolStripMenuItem,
            this.moveEntryOutToolStripMenuItem,
            this.moveEntryInToolStripMenuItem});
            this.moveEntriesToolStripMenuItem.Name = "moveEntriesToolStripMenuItem";
            resources.ApplyResources(this.moveEntriesToolStripMenuItem, "moveEntriesToolStripMenuItem");
            // 
            // moveEntryUpToolStripMenuItem
            // 
            this.moveEntryUpToolStripMenuItem.Name = "moveEntryUpToolStripMenuItem";
            resources.ApplyResources(this.moveEntryUpToolStripMenuItem, "moveEntryUpToolStripMenuItem");
            this.moveEntryUpToolStripMenuItem.Click += new System.EventHandler(this.MoveEntryUpClickHandler);
            // 
            // moveEntryDownToolStripMenuItem
            // 
            this.moveEntryDownToolStripMenuItem.Name = "moveEntryDownToolStripMenuItem";
            resources.ApplyResources(this.moveEntryDownToolStripMenuItem, "moveEntryDownToolStripMenuItem");
            this.moveEntryDownToolStripMenuItem.Click += new System.EventHandler(this.MoveEntryDownClickHandler);
            // 
            // moveEntryOutToolStripMenuItem
            // 
            this.moveEntryOutToolStripMenuItem.Name = "moveEntryOutToolStripMenuItem";
            resources.ApplyResources(this.moveEntryOutToolStripMenuItem, "moveEntryOutToolStripMenuItem");
            this.moveEntryOutToolStripMenuItem.Click += new System.EventHandler(this.MoveEntryOutClickHandler);
            // 
            // moveEntryInToolStripMenuItem
            // 
            this.moveEntryInToolStripMenuItem.Name = "moveEntryInToolStripMenuItem";
            resources.ApplyResources(this.moveEntryInToolStripMenuItem, "moveEntryInToolStripMenuItem");
            this.moveEntryInToolStripMenuItem.Click += new System.EventHandler(this.MoveEntryInClickHandler);
            // 
            // reloadMacroEntriesToolStripMenuItem
            // 
            this.reloadMacroEntriesToolStripMenuItem.Name = "reloadMacroEntriesToolStripMenuItem";
            resources.ApplyResources(this.reloadMacroEntriesToolStripMenuItem, "reloadMacroEntriesToolStripMenuItem");
            this.reloadMacroEntriesToolStripMenuItem.Click += new System.EventHandler(this.ReloadMacroEntriesClickHandler);
            // 
            // deleteEntryToolStripMenuItem
            // 
            this.deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            resources.ApplyResources(this.deleteEntryToolStripMenuItem, "deleteEntryToolStripMenuItem");
            this.deleteEntryToolStripMenuItem.Click += new System.EventHandler(this.DeleteEntryClickHandler);
            // 
            // addDTBToolStripMenuItem
            // 
            this.addDTBToolStripMenuItem.Name = "addDTBToolStripMenuItem";
            resources.ApplyResources(this.addDTBToolStripMenuItem, "addDTBToolStripMenuItem");
            this.addDTBToolStripMenuItem.Click += new System.EventHandler(this.AddDTBClickHandler);
            // 
            // insertDTBToolStripMenuItem
            // 
            this.insertDTBToolStripMenuItem.Name = "insertDTBToolStripMenuItem";
            resources.ApplyResources(this.insertDTBToolStripMenuItem, "insertDTBToolStripMenuItem");
            this.insertDTBToolStripMenuItem.Click += new System.EventHandler(this.InsertDTBClickHandler);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            resources.ApplyResources(this.undoToolStripMenuItem, "undoToolStripMenuItem");
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoClickHandler);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            resources.ApplyResources(this.redoToolStripMenuItem, "redoToolStripMenuItem");
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoClickHandler);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateMergedDtbToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            resources.ApplyResources(this.actionsToolStripMenuItem, "actionsToolStripMenuItem");
            // 
            // generateMergedDtbToolStripMenuItem
            // 
            this.generateMergedDtbToolStripMenuItem.Name = "generateMergedDtbToolStripMenuItem";
            resources.ApplyResources(this.generateMergedDtbToolStripMenuItem, "generateMergedDtbToolStripMenuItem");
            this.generateMergedDtbToolStripMenuItem.Click += new System.EventHandler(this.GenerateMergedDtbClickHandler);
            // 
            // mainTableLayoutPanel
            // 
            resources.ApplyResources(this.mainTableLayoutPanel, "mainTableLayoutPanel");
            this.mainTableLayoutPanel.Controls.Add(this.cancelButton, 5, 4);
            this.mainTableLayoutPanel.Controls.Add(this.undoButton, 3, 3);
            this.mainTableLayoutPanel.Controls.Add(this.redoButton, 5, 3);
            this.mainTableLayoutPanel.Controls.Add(this.addDTBButton, 3, 1);
            this.mainTableLayoutPanel.Controls.Add(this.insertDTBButton, 5, 1);
            this.mainTableLayoutPanel.Controls.Add(this.saveMacro, 1, 5);
            this.mainTableLayoutPanel.Controls.Add(this.exitButton, 5, 5);
            this.mainTableLayoutPanel.Controls.Add(this.macroTreeView, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.propertiesDataGridView, 3, 0);
            this.mainTableLayoutPanel.Controls.Add(this.openMacroButton, 0, 5);
            this.mainTableLayoutPanel.Controls.Add(this.moveEntryUpButton, 4, 1);
            this.mainTableLayoutPanel.Controls.Add(this.moveEntryOutButton, 3, 2);
            this.mainTableLayoutPanel.Controls.Add(this.deleteEntryButton, 4, 2);
            this.mainTableLayoutPanel.Controls.Add(this.moveEntryInButton, 5, 2);
            this.mainTableLayoutPanel.Controls.Add(this.moveEntryDownButton, 4, 3);
            this.mainTableLayoutPanel.Controls.Add(this.buildProgressBar, 0, 4);
            this.mainTableLayoutPanel.Controls.Add(this.buildMessageLabel, 2, 4);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClickHandler);
            // 
            // undoButton
            // 
            resources.ApplyResources(this.undoButton, "undoButton");
            this.undoButton.Name = "undoButton";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoClickHandler);
            // 
            // redoButton
            // 
            resources.ApplyResources(this.redoButton, "redoButton");
            this.redoButton.Name = "redoButton";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.RedoClickHandler);
            // 
            // addDTBButton
            // 
            resources.ApplyResources(this.addDTBButton, "addDTBButton");
            this.addDTBButton.Name = "addDTBButton";
            this.addDTBButton.UseVisualStyleBackColor = true;
            this.addDTBButton.Click += new System.EventHandler(this.AddDTBClickHandler);
            // 
            // insertDTBButton
            // 
            resources.ApplyResources(this.insertDTBButton, "insertDTBButton");
            this.insertDTBButton.Name = "insertDTBButton";
            this.insertDTBButton.UseVisualStyleBackColor = true;
            this.insertDTBButton.Click += new System.EventHandler(this.InsertDTBClickHandler);
            // 
            // saveMacro
            // 
            resources.ApplyResources(this.saveMacro, "saveMacro");
            this.saveMacro.Name = "saveMacro";
            this.saveMacro.UseVisualStyleBackColor = true;
            this.saveMacro.Click += new System.EventHandler(this.SaveMacroClickHandler);
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitClickHandler);
            // 
            // macroTreeView
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.macroTreeView, 3);
            resources.ApplyResources(this.macroTreeView, "macroTreeView");
            this.macroTreeView.HideSelection = false;
            this.macroTreeView.Name = "macroTreeView";
            this.mainTableLayoutPanel.SetRowSpan(this.macroTreeView, 4);
            this.macroTreeView.ShowLines = false;
            this.macroTreeView.ShowRootLines = false;
            this.macroTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.MacroTreeViewAfterCollapseHandler);
            this.macroTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.MacroTreeViewAfterExpandHandler);
            this.macroTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MacroTreeViewAfterSelectHandler);
            // 
            // propertiesDataGridView
            // 
            this.propertiesDataGridView.AllowUserToAddRows = false;
            this.propertiesDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.propertiesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.propertiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propertiesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObjectColumn,
            this.NameColumn,
            this.ValueColumn});
            this.mainTableLayoutPanel.SetColumnSpan(this.propertiesDataGridView, 3);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.propertiesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.propertiesDataGridView, "propertiesDataGridView");
            this.propertiesDataGridView.Name = "propertiesDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.propertiesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.propertiesDataGridView.RowTemplate.Height = 24;
            this.propertiesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PropertiesDataGridViewCellValueChangedHandler);
            // 
            // ObjectColumn
            // 
            resources.ApplyResources(this.ObjectColumn, "ObjectColumn");
            this.ObjectColumn.Name = "ObjectColumn";
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameColumn.FillWeight = 25F;
            resources.ApplyResources(this.NameColumn, "NameColumn");
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // ValueColumn
            // 
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValueColumn.FillWeight = 75F;
            resources.ApplyResources(this.ValueColumn, "ValueColumn");
            this.ValueColumn.Name = "ValueColumn";
            // 
            // openMacroButton
            // 
            resources.ApplyResources(this.openMacroButton, "openMacroButton");
            this.openMacroButton.Name = "openMacroButton";
            this.openMacroButton.UseVisualStyleBackColor = true;
            this.openMacroButton.Click += new System.EventHandler(this.OpenMacroClickHandler);
            // 
            // moveEntryUpButton
            // 
            resources.ApplyResources(this.moveEntryUpButton, "moveEntryUpButton");
            this.moveEntryUpButton.Name = "moveEntryUpButton";
            this.moveEntryUpButton.UseVisualStyleBackColor = true;
            this.moveEntryUpButton.Click += new System.EventHandler(this.MoveEntryUpClickHandler);
            // 
            // moveEntryOutButton
            // 
            resources.ApplyResources(this.moveEntryOutButton, "moveEntryOutButton");
            this.moveEntryOutButton.Name = "moveEntryOutButton";
            this.moveEntryOutButton.UseVisualStyleBackColor = true;
            this.moveEntryOutButton.Click += new System.EventHandler(this.MoveEntryOutClickHandler);
            // 
            // deleteEntryButton
            // 
            resources.ApplyResources(this.deleteEntryButton, "deleteEntryButton");
            this.deleteEntryButton.Name = "deleteEntryButton";
            this.deleteEntryButton.UseVisualStyleBackColor = true;
            this.deleteEntryButton.Click += new System.EventHandler(this.DeleteEntryClickHandler);
            // 
            // moveEntryInButton
            // 
            resources.ApplyResources(this.moveEntryInButton, "moveEntryInButton");
            this.moveEntryInButton.Name = "moveEntryInButton";
            this.moveEntryInButton.UseVisualStyleBackColor = true;
            this.moveEntryInButton.Click += new System.EventHandler(this.MoveEntryInClickHandler);
            // 
            // moveEntryDownButton
            // 
            resources.ApplyResources(this.moveEntryDownButton, "moveEntryDownButton");
            this.moveEntryDownButton.Name = "moveEntryDownButton";
            this.moveEntryDownButton.UseVisualStyleBackColor = true;
            this.moveEntryDownButton.Click += new System.EventHandler(this.MoveEntryDownClickHandler);
            // 
            // buildProgressBar
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.buildProgressBar, 2);
            resources.ApplyResources(this.buildProgressBar, "buildProgressBar");
            this.buildProgressBar.Name = "buildProgressBar";
            this.buildProgressBar.Step = 1;
            this.buildProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // buildMessageLabel
            // 
            resources.ApplyResources(this.buildMessageLabel, "buildMessageLabel");
            this.mainTableLayoutPanel.SetColumnSpan(this.buildMessageLabel, 3);
            this.buildMessageLabel.Name = "buildMessageLabel";
            // 
            // saveDtbBackgroundWorker
            // 
            this.saveDtbBackgroundWorker.WorkerReportsProgress = true;
            this.saveDtbBackgroundWorker.WorkerSupportsCancellation = true;
            this.saveDtbBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GenerateDtbBackgroundWorkerDoWorkHandler);
            this.saveDtbBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.GenerateDtbBackgroundWorkerProgressChangedHandler);
            this.saveDtbBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SaveDtbBackgroundWorkerRunWorkerCompletedHandler);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosingHandler);
            this.Load += new System.EventHandler(this.MainFormLoadHandler);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMacroToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TreeView macroTreeView;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView propertiesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.ToolStripMenuItem saveMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button saveMacro;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button openMacroButton;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEntryUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEntryDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEntryOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEntryInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadMacroEntriesToolStripMenuItem;
        private System.Windows.Forms.Button moveEntryUpButton;
        private System.Windows.Forms.Button moveEntryOutButton;
        private System.Windows.Forms.Button deleteEntryButton;
        private System.Windows.Forms.Button moveEntryInButton;
        private System.Windows.Forms.Button moveEntryDownButton;
        private System.Windows.Forms.ToolStripMenuItem deleteEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertDTBToolStripMenuItem;
        private System.Windows.Forms.Button insertDTBButton;
        private System.Windows.Forms.ToolStripMenuItem addDTBToolStripMenuItem;
        private System.Windows.Forms.Button addDTBButton;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateMergedDtbToolStripMenuItem;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar buildProgressBar;
        private System.ComponentModel.BackgroundWorker saveDtbBackgroundWorker;
        private System.Windows.Forms.Label buildMessageLabel;
    }
}

