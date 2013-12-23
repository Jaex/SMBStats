namespace SMBStats
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
            this.cmsChapters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiChaptersCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChaptersCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.olvLevels = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnLevels = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnParTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnGradeA = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnBandage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnWarp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmsLevels = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiLevelsLeaderboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevelsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLevelsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevelsCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cbLevelType = new System.Windows.Forms.ComboBox();
            this.lblLevelType = new System.Windows.Forms.Label();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbLoad = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbCopyAll = new System.Windows.Forms.ToolStripButton();
            this.tsbCopySelected = new System.Windows.Forms.ToolStripButton();
            this.tsbLeaderboard = new System.Windows.Forms.ToolStripButton();
            this.tsbUnpackData = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.btnNextType = new System.Windows.Forms.Button();
            this.cmsStats = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiStatsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatsCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCompare = new System.Windows.Forms.CheckBox();
            this.cmsCompare = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCompareCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompareCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCompareFilter = new System.Windows.Forms.ComboBox();
            this.tcStats = new System.Windows.Forms.TabControl();
            this.tpTotalStats = new System.Windows.Forms.TabPage();
            this.lvStats = new HelpersLibrary.MyListView();
            this.chStatsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatsValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpChapterStats = new System.Windows.Forms.TabPage();
            this.lvChapterStats = new HelpersLibrary.MyListView();
            this.chChapterStatsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chChapterStatsValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsChapterStats = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiChapterStatsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChapterStatsCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tpCharacters = new System.Windows.Forms.TabPage();
            this.olvCharacters = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnCharactersName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCharactersWhere = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCharactersRequirement = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCharactersStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lvChapters = new HelpersLibrary.MyListView();
            this.chChapters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBandage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWarp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCompare = new HelpersLibrary.MyListView();
            this.chCompareLevelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCompareTime1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCompareTime2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCompareDifference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCompareParTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsChapters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvLevels)).BeginInit();
            this.cmsLevels.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.cmsStats.SuspendLayout();
            this.cmsCompare.SuspendLayout();
            this.tcStats.SuspendLayout();
            this.tpTotalStats.SuspendLayout();
            this.tpChapterStats.SuspendLayout();
            this.cmsChapterStats.SuspendLayout();
            this.tpCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvCharacters)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsChapters
            // 
            this.cmsChapters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChaptersCopy,
            this.tsmiChaptersCopyAll});
            this.cmsChapters.Name = "cmsChapters";
            this.cmsChapters.ShowImageMargin = false;
            this.cmsChapters.Size = new System.Drawing.Size(93, 48);
            // 
            // tsmiChaptersCopy
            // 
            this.tsmiChaptersCopy.Name = "tsmiChaptersCopy";
            this.tsmiChaptersCopy.Size = new System.Drawing.Size(92, 22);
            this.tsmiChaptersCopy.Text = "Copy";
            this.tsmiChaptersCopy.Click += new System.EventHandler(this.tsmiChaptersCopy_Click);
            // 
            // tsmiChaptersCopyAll
            // 
            this.tsmiChaptersCopyAll.Name = "tsmiChaptersCopyAll";
            this.tsmiChaptersCopyAll.Size = new System.Drawing.Size(92, 22);
            this.tsmiChaptersCopyAll.Text = "Copy all";
            this.tsmiChaptersCopyAll.Click += new System.EventHandler(this.tsmiChaptersCopyAll_Click);
            // 
            // olvLevels
            // 
            this.olvLevels.AllColumns.Add(this.olvColumnLevels);
            this.olvLevels.AllColumns.Add(this.olvColumnTime);
            this.olvLevels.AllColumns.Add(this.olvColumnParTime);
            this.olvLevels.AllColumns.Add(this.olvColumnGradeA);
            this.olvLevels.AllColumns.Add(this.olvColumnBandage);
            this.olvLevels.AllColumns.Add(this.olvColumnWarp);
            this.olvLevels.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.olvLevels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.olvLevels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnLevels,
            this.olvColumnTime,
            this.olvColumnParTime,
            this.olvColumnGradeA,
            this.olvColumnBandage,
            this.olvColumnWarp});
            this.olvLevels.ContextMenuStrip = this.cmsLevels;
            this.olvLevels.FullRowSelect = true;
            this.olvLevels.GridLines = true;
            this.olvLevels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.olvLevels.Location = new System.Drawing.Point(472, 72);
            this.olvLevels.Name = "olvLevels";
            this.olvLevels.OwnerDraw = true;
            this.olvLevels.ShowGroups = false;
            this.olvLevels.Size = new System.Drawing.Size(448, 373);
            this.olvLevels.TabIndex = 6;
            this.olvLevels.UseAlternatingBackColors = true;
            this.olvLevels.UseCompatibleStateImageBehavior = false;
            this.olvLevels.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnLevels
            // 
            this.olvColumnLevels.AspectName = "LevelNameWithNumber";
            this.olvColumnLevels.FillsFreeSpace = true;
            this.olvColumnLevels.Text = "Level name";
            this.olvColumnLevels.Width = 125;
            // 
            // olvColumnTime
            // 
            this.olvColumnTime.AspectName = "TimeText";
            this.olvColumnTime.AspectToStringFormat = "{0:0.000}";
            this.olvColumnTime.Text = "Time";
            // 
            // olvColumnParTime
            // 
            this.olvColumnParTime.AspectName = "ParTime";
            this.olvColumnParTime.AspectToStringFormat = "{0:0.000}";
            this.olvColumnParTime.Text = "Par time";
            // 
            // olvColumnGradeA
            // 
            this.olvColumnGradeA.AspectName = "GetCompletedStatus";
            this.olvColumnGradeA.AspectToStringFormat = "";
            this.olvColumnGradeA.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnGradeA.Text = "Status";
            this.olvColumnGradeA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumnBandage
            // 
            this.olvColumnBandage.AspectName = "GetBandageStatus";
            this.olvColumnBandage.AspectToStringFormat = "";
            this.olvColumnBandage.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnBandage.Text = "Bandage";
            this.olvColumnBandage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumnWarp
            // 
            this.olvColumnWarp.AspectName = "GetWarpStatus";
            this.olvColumnWarp.AspectToStringFormat = "";
            this.olvColumnWarp.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnWarp.Text = "Warp";
            this.olvColumnWarp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmsLevels
            // 
            this.cmsLevels.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLevelsLeaderboard,
            this.tsmiLevelsSeparator,
            this.tsmiLevelsCopy,
            this.tsmiLevelsCopyAll});
            this.cmsLevels.Name = "cmsLevels";
            this.cmsLevels.ShowImageMargin = false;
            this.cmsLevels.Size = new System.Drawing.Size(125, 76);
            // 
            // tsmiLevelsLeaderboard
            // 
            this.tsmiLevelsLeaderboard.Name = "tsmiLevelsLeaderboard";
            this.tsmiLevelsLeaderboard.Size = new System.Drawing.Size(124, 22);
            this.tsmiLevelsLeaderboard.Text = "Leaderboard...";
            this.tsmiLevelsLeaderboard.Click += new System.EventHandler(this.tsmiLevelsLeaderboard_Click);
            // 
            // tsmiLevelsSeparator
            // 
            this.tsmiLevelsSeparator.Name = "tsmiLevelsSeparator";
            this.tsmiLevelsSeparator.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmiLevelsCopy
            // 
            this.tsmiLevelsCopy.Name = "tsmiLevelsCopy";
            this.tsmiLevelsCopy.Size = new System.Drawing.Size(124, 22);
            this.tsmiLevelsCopy.Text = "Copy";
            this.tsmiLevelsCopy.Click += new System.EventHandler(this.tsmiLevelsCopy_Click);
            // 
            // tsmiLevelsCopyAll
            // 
            this.tsmiLevelsCopyAll.Name = "tsmiLevelsCopyAll";
            this.tsmiLevelsCopyAll.Size = new System.Drawing.Size(124, 22);
            this.tsmiLevelsCopyAll.Text = "Copy all";
            this.tsmiLevelsCopyAll.Click += new System.EventHandler(this.tsmiLevelsCopyAll_Click);
            // 
            // cbLevelType
            // 
            this.cbLevelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevelType.FormattingEnabled = true;
            this.cbLevelType.Items.AddRange(new object[] {
            "All",
            "Light",
            "Dark",
            "Warp"});
            this.cbLevelType.Location = new System.Drawing.Point(536, 44);
            this.cbLevelType.Name = "cbLevelType";
            this.cbLevelType.Size = new System.Drawing.Size(56, 21);
            this.cbLevelType.TabIndex = 7;
            this.cbLevelType.SelectedIndexChanged += new System.EventHandler(this.cbLevelType_SelectedIndexChanged);
            // 
            // lblLevelType
            // 
            this.lblLevelType.AutoSize = true;
            this.lblLevelType.Location = new System.Drawing.Point(472, 48);
            this.lblLevelType.Name = "lblLevelType";
            this.lblLevelType.Size = new System.Drawing.Size(59, 13);
            this.lblLevelType.TabIndex = 8;
            this.lblLevelType.Text = "Level type:";
            // 
            // tsMenu
            // 
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoad,
            this.tsbRefresh,
            this.tsbCopyAll,
            this.tsbCopySelected,
            this.tsbLeaderboard,
            this.tsbUnpackData,
            this.tsbSettings,
            this.tsbAbout});
            this.tsMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsMenu.Location = new System.Drawing.Point(8, 8);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(667, 25);
            this.tsMenu.TabIndex = 12;
            // 
            // tsbLoad
            // 
            this.tsbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoad.Image")));
            this.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoad.Name = "tsbLoad";
            this.tsbLoad.Size = new System.Drawing.Size(62, 22);
            this.tsbLoad.Text = "Load...";
            this.tsbLoad.Click += new System.EventHandler(this.tsbLoad_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Enabled = false;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(66, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbCopyAll
            // 
            this.tsbCopyAll.Enabled = false;
            this.tsbCopyAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopyAll.Image")));
            this.tsbCopyAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopyAll.Name = "tsbCopyAll";
            this.tsbCopyAll.Size = new System.Drawing.Size(70, 22);
            this.tsbCopyAll.Text = "Copy all";
            this.tsbCopyAll.Click += new System.EventHandler(this.tsbCopyAll_Click);
            // 
            // tsbCopySelected
            // 
            this.tsbCopySelected.Enabled = false;
            this.tsbCopySelected.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopySelected.Image")));
            this.tsbCopySelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopySelected.Name = "tsbCopySelected";
            this.tsbCopySelected.Size = new System.Drawing.Size(101, 22);
            this.tsbCopySelected.Text = "Copy selected";
            this.tsbCopySelected.Click += new System.EventHandler(this.tsbCopySelected_Click);
            // 
            // tsbLeaderboard
            // 
            this.tsbLeaderboard.Image = ((System.Drawing.Image)(resources.GetObject("tsbLeaderboard.Image")));
            this.tsbLeaderboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLeaderboard.Name = "tsbLeaderboard";
            this.tsbLeaderboard.Size = new System.Drawing.Size(107, 22);
            this.tsbLeaderboard.Text = "Leaderboards...";
            this.tsbLeaderboard.Click += new System.EventHandler(this.tsbLeaderboard_Click);
            // 
            // tsbUnpackData
            // 
            this.tsbUnpackData.Image = ((System.Drawing.Image)(resources.GetObject("tsbUnpackData.Image")));
            this.tsbUnpackData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnpackData.Name = "tsbUnpackData";
            this.tsbUnpackData.Size = new System.Drawing.Size(102, 22);
            this.tsbUnpackData.Text = "Unpack data...";
            this.tsbUnpackData.Click += new System.EventHandler(this.tsbUnpack_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(78, 22);
            this.tsbSettings.Text = "Settings...";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(69, 22);
            this.tsbAbout.Text = "About...";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // btnNextType
            // 
            this.btnNextType.Location = new System.Drawing.Point(600, 43);
            this.btnNextType.Name = "btnNextType";
            this.btnNextType.Size = new System.Drawing.Size(40, 23);
            this.btnNextType.TabIndex = 13;
            this.btnNextType.Text = "Next";
            this.btnNextType.UseVisualStyleBackColor = true;
            this.btnNextType.Click += new System.EventHandler(this.btnNextType_Click);
            // 
            // cmsStats
            // 
            this.cmsStats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStatsCopy,
            this.tsmiStatsCopyAll});
            this.cmsStats.Name = "cmsStats";
            this.cmsStats.ShowImageMargin = false;
            this.cmsStats.Size = new System.Drawing.Size(93, 48);
            // 
            // tsmiStatsCopy
            // 
            this.tsmiStatsCopy.Name = "tsmiStatsCopy";
            this.tsmiStatsCopy.Size = new System.Drawing.Size(92, 22);
            this.tsmiStatsCopy.Text = "Copy";
            this.tsmiStatsCopy.Click += new System.EventHandler(this.tsmiStatsCopy_Click);
            // 
            // tsmiStatsCopyAll
            // 
            this.tsmiStatsCopyAll.Name = "tsmiStatsCopyAll";
            this.tsmiStatsCopyAll.Size = new System.Drawing.Size(92, 22);
            this.tsmiStatsCopyAll.Text = "Copy all";
            this.tsmiStatsCopyAll.Click += new System.EventHandler(this.tsmiStatsCopyAll_Click);
            // 
            // cbCompare
            // 
            this.cbCompare.AutoSize = true;
            this.cbCompare.Location = new System.Drawing.Point(656, 47);
            this.cbCompare.Name = "cbCompare";
            this.cbCompare.Size = new System.Drawing.Size(100, 17);
            this.cbCompare.TabIndex = 16;
            this.cbCompare.Text = "Compare mode:";
            this.cbCompare.UseVisualStyleBackColor = true;
            this.cbCompare.CheckedChanged += new System.EventHandler(this.cbCompare_CheckedChanged);
            // 
            // cmsCompare
            // 
            this.cmsCompare.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCompareCopy,
            this.tsmiCompareCopyAll});
            this.cmsCompare.Name = "cmsCompare";
            this.cmsCompare.ShowImageMargin = false;
            this.cmsCompare.Size = new System.Drawing.Size(93, 48);
            // 
            // tsmiCompareCopy
            // 
            this.tsmiCompareCopy.Name = "tsmiCompareCopy";
            this.tsmiCompareCopy.Size = new System.Drawing.Size(92, 22);
            this.tsmiCompareCopy.Text = "Copy";
            this.tsmiCompareCopy.Click += new System.EventHandler(this.tsmiCompareCopy_Click);
            // 
            // tsmiCompareCopyAll
            // 
            this.tsmiCompareCopyAll.Name = "tsmiCompareCopyAll";
            this.tsmiCompareCopyAll.Size = new System.Drawing.Size(92, 22);
            this.tsmiCompareCopyAll.Text = "Copy all";
            this.tsmiCompareCopyAll.Click += new System.EventHandler(this.tsmiCompareCopyAll_Click);
            // 
            // cbCompareFilter
            // 
            this.cbCompareFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompareFilter.FormattingEnabled = true;
            this.cbCompareFilter.Items.AddRange(new object[] {
            "All",
            ">",
            "<"});
            this.cbCompareFilter.Location = new System.Drawing.Point(760, 44);
            this.cbCompareFilter.Name = "cbCompareFilter";
            this.cbCompareFilter.Size = new System.Drawing.Size(48, 21);
            this.cbCompareFilter.TabIndex = 17;
            this.cbCompareFilter.SelectedIndexChanged += new System.EventHandler(this.cbCompareFilter_SelectedIndexChanged);
            // 
            // tcStats
            // 
            this.tcStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tcStats.Controls.Add(this.tpTotalStats);
            this.tcStats.Controls.Add(this.tpChapterStats);
            this.tcStats.Controls.Add(this.tpCharacters);
            this.tcStats.Location = new System.Drawing.Point(8, 208);
            this.tcStats.Name = "tcStats";
            this.tcStats.SelectedIndex = 0;
            this.tcStats.Size = new System.Drawing.Size(456, 237);
            this.tcStats.TabIndex = 18;
            // 
            // tpTotalStats
            // 
            this.tpTotalStats.Controls.Add(this.lvStats);
            this.tpTotalStats.Location = new System.Drawing.Point(4, 22);
            this.tpTotalStats.Name = "tpTotalStats";
            this.tpTotalStats.Padding = new System.Windows.Forms.Padding(3);
            this.tpTotalStats.Size = new System.Drawing.Size(448, 211);
            this.tpTotalStats.TabIndex = 0;
            this.tpTotalStats.Text = "Total stats";
            this.tpTotalStats.UseVisualStyleBackColor = true;
            // 
            // lvStats
            // 
            this.lvStats.AutoFillColumn = true;
            this.lvStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chStatsName,
            this.chStatsValue});
            this.lvStats.ContextMenuStrip = this.cmsStats;
            this.lvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStats.FullRowSelect = true;
            this.lvStats.GridLines = true;
            this.lvStats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStats.Location = new System.Drawing.Point(3, 3);
            this.lvStats.Margin = new System.Windows.Forms.Padding(0);
            this.lvStats.Name = "lvStats";
            this.lvStats.Size = new System.Drawing.Size(442, 205);
            this.lvStats.TabIndex = 14;
            this.lvStats.UseCompatibleStateImageBehavior = false;
            this.lvStats.View = System.Windows.Forms.View.Details;
            // 
            // chStatsName
            // 
            this.chStatsName.Text = "Name";
            this.chStatsName.Width = 200;
            // 
            // chStatsValue
            // 
            this.chStatsValue.Text = "Value";
            this.chStatsValue.Width = 200;
            // 
            // tpChapterStats
            // 
            this.tpChapterStats.Controls.Add(this.lvChapterStats);
            this.tpChapterStats.Location = new System.Drawing.Point(4, 22);
            this.tpChapterStats.Name = "tpChapterStats";
            this.tpChapterStats.Padding = new System.Windows.Forms.Padding(3);
            this.tpChapterStats.Size = new System.Drawing.Size(448, 211);
            this.tpChapterStats.TabIndex = 1;
            this.tpChapterStats.Text = "Chapter stats";
            this.tpChapterStats.UseVisualStyleBackColor = true;
            // 
            // lvChapterStats
            // 
            this.lvChapterStats.AutoFillColumn = true;
            this.lvChapterStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvChapterStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chChapterStatsName,
            this.chChapterStatsValue});
            this.lvChapterStats.ContextMenuStrip = this.cmsChapterStats;
            this.lvChapterStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChapterStats.FullRowSelect = true;
            this.lvChapterStats.GridLines = true;
            this.lvChapterStats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvChapterStats.Location = new System.Drawing.Point(3, 3);
            this.lvChapterStats.Name = "lvChapterStats";
            this.lvChapterStats.Size = new System.Drawing.Size(442, 205);
            this.lvChapterStats.TabIndex = 15;
            this.lvChapterStats.UseCompatibleStateImageBehavior = false;
            this.lvChapterStats.View = System.Windows.Forms.View.Details;
            // 
            // chChapterStatsName
            // 
            this.chChapterStatsName.Text = "Name";
            this.chChapterStatsName.Width = 200;
            // 
            // chChapterStatsValue
            // 
            this.chChapterStatsValue.Text = "Value";
            this.chChapterStatsValue.Width = 200;
            // 
            // cmsChapterStats
            // 
            this.cmsChapterStats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChapterStatsCopy,
            this.tsmiChapterStatsCopyAll});
            this.cmsChapterStats.Name = "cmsChapterStats";
            this.cmsChapterStats.ShowImageMargin = false;
            this.cmsChapterStats.Size = new System.Drawing.Size(93, 48);
            // 
            // tsmiChapterStatsCopy
            // 
            this.tsmiChapterStatsCopy.Name = "tsmiChapterStatsCopy";
            this.tsmiChapterStatsCopy.Size = new System.Drawing.Size(92, 22);
            this.tsmiChapterStatsCopy.Text = "Copy";
            this.tsmiChapterStatsCopy.Click += new System.EventHandler(this.tsmiChapterStatsCopy_Click);
            // 
            // tsmiChapterStatsCopyAll
            // 
            this.tsmiChapterStatsCopyAll.Name = "tsmiChapterStatsCopyAll";
            this.tsmiChapterStatsCopyAll.Size = new System.Drawing.Size(92, 22);
            this.tsmiChapterStatsCopyAll.Text = "Copy all";
            this.tsmiChapterStatsCopyAll.Click += new System.EventHandler(this.tsmiChapterStatsCopyAll_Click);
            // 
            // tpCharacters
            // 
            this.tpCharacters.Controls.Add(this.olvCharacters);
            this.tpCharacters.Location = new System.Drawing.Point(4, 22);
            this.tpCharacters.Name = "tpCharacters";
            this.tpCharacters.Padding = new System.Windows.Forms.Padding(3);
            this.tpCharacters.Size = new System.Drawing.Size(448, 211);
            this.tpCharacters.TabIndex = 2;
            this.tpCharacters.Text = "Characters";
            this.tpCharacters.UseVisualStyleBackColor = true;
            // 
            // olvCharacters
            // 
            this.olvCharacters.AllColumns.Add(this.olvColumnCharactersName);
            this.olvCharacters.AllColumns.Add(this.olvColumnCharactersWhere);
            this.olvCharacters.AllColumns.Add(this.olvColumnCharactersRequirement);
            this.olvCharacters.AllColumns.Add(this.olvColumnCharactersStatus);
            this.olvCharacters.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.olvCharacters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnCharactersName,
            this.olvColumnCharactersWhere,
            this.olvColumnCharactersRequirement,
            this.olvColumnCharactersStatus});
            this.olvCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvCharacters.FullRowSelect = true;
            this.olvCharacters.Location = new System.Drawing.Point(3, 3);
            this.olvCharacters.Name = "olvCharacters";
            this.olvCharacters.OwnerDraw = true;
            this.olvCharacters.ShowGroups = false;
            this.olvCharacters.Size = new System.Drawing.Size(442, 205);
            this.olvCharacters.TabIndex = 15;
            this.olvCharacters.UseAlternatingBackColors = true;
            this.olvCharacters.UseCompatibleStateImageBehavior = false;
            this.olvCharacters.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnCharactersName
            // 
            this.olvColumnCharactersName.AspectName = "Name";
            this.olvColumnCharactersName.ImageAspectName = "";
            this.olvColumnCharactersName.Text = "Name";
            this.olvColumnCharactersName.Width = 125;
            // 
            // olvColumnCharactersWhere
            // 
            this.olvColumnCharactersWhere.AspectName = "Origin";
            this.olvColumnCharactersWhere.Text = "Origin";
            this.olvColumnCharactersWhere.Width = 125;
            // 
            // olvColumnCharactersRequirement
            // 
            this.olvColumnCharactersRequirement.AspectName = "Requirement";
            this.olvColumnCharactersRequirement.FillsFreeSpace = true;
            this.olvColumnCharactersRequirement.Text = "Requirement";
            this.olvColumnCharactersRequirement.Width = 125;
            // 
            // olvColumnCharactersStatus
            // 
            this.olvColumnCharactersStatus.AspectName = "IsUnlocked";
            this.olvColumnCharactersStatus.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnCharactersStatus.Text = "Status";
            this.olvColumnCharactersStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnCharactersStatus.Width = 45;
            // 
            // lvChapters
            // 
            this.lvChapters.AutoFillColumn = true;
            this.lvChapters.AutoFillColumnIndex = 0;
            this.lvChapters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chChapters,
            this.chLight,
            this.chDark,
            this.chBandage,
            this.chWarp,
            this.chProgress});
            this.lvChapters.ContextMenuStrip = this.cmsChapters;
            this.lvChapters.FullRowSelect = true;
            this.lvChapters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChapters.HideSelection = false;
            this.lvChapters.Location = new System.Drawing.Point(8, 40);
            this.lvChapters.Name = "lvChapters";
            this.lvChapters.Size = new System.Drawing.Size(456, 160);
            this.lvChapters.TabIndex = 4;
            this.lvChapters.UseCompatibleStateImageBehavior = false;
            this.lvChapters.View = System.Windows.Forms.View.Details;
            this.lvChapters.SelectedIndexChanged += new System.EventHandler(this.lvChapters_SelectedIndexChanged);
            // 
            // chChapters
            // 
            this.chChapters.Text = "Chapter name";
            this.chChapters.Width = 120;
            // 
            // chLight
            // 
            this.chLight.Text = "Light";
            this.chLight.Width = 55;
            // 
            // chDark
            // 
            this.chDark.Text = "Dark";
            this.chDark.Width = 55;
            // 
            // chBandage
            // 
            this.chBandage.Text = "Bandage";
            this.chBandage.Width = 55;
            // 
            // chWarp
            // 
            this.chWarp.Text = "Warp";
            this.chWarp.Width = 55;
            // 
            // chProgress
            // 
            this.chProgress.Text = "Progress";
            this.chProgress.Width = 55;
            // 
            // lvCompare
            // 
            this.lvCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvCompare.AutoFillColumn = true;
            this.lvCompare.AutoFillColumnIndex = 0;
            this.lvCompare.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCompareLevelName,
            this.chCompareTime1,
            this.chCompareTime2,
            this.chCompareDifference,
            this.chCompareParTime});
            this.lvCompare.ContextMenuStrip = this.cmsCompare;
            this.lvCompare.FullRowSelect = true;
            this.lvCompare.GridLines = true;
            this.lvCompare.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCompare.Location = new System.Drawing.Point(472, 72);
            this.lvCompare.Name = "lvCompare";
            this.lvCompare.Size = new System.Drawing.Size(448, 373);
            this.lvCompare.TabIndex = 15;
            this.lvCompare.UseCompatibleStateImageBehavior = false;
            this.lvCompare.View = System.Windows.Forms.View.Details;
            this.lvCompare.Visible = false;
            // 
            // chCompareLevelName
            // 
            this.chCompareLevelName.Text = "Level name";
            this.chCompareLevelName.Width = 164;
            // 
            // chCompareTime1
            // 
            this.chCompareTime1.Text = "Time 1";
            this.chCompareTime1.Width = 70;
            // 
            // chCompareTime2
            // 
            this.chCompareTime2.Text = "Time 2";
            this.chCompareTime2.Width = 70;
            // 
            // chCompareDifference
            // 
            this.chCompareDifference.Text = "Difference";
            this.chCompareDifference.Width = 70;
            // 
            // chCompareParTime
            // 
            this.chCompareParTime.Text = "Par time";
            this.chCompareParTime.Width = 70;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 454);
            this.Controls.Add(this.tcStats);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.lvChapters);
            this.Controls.Add(this.olvLevels);
            this.Controls.Add(this.lvCompare);
            this.Controls.Add(this.lblLevelType);
            this.Controls.Add(this.cbCompareFilter);
            this.Controls.Add(this.cbCompare);
            this.Controls.Add(this.btnNextType);
            this.Controls.Add(this.cbLevelType);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(945, 1000);
            this.MinimumSize = new System.Drawing.Size(945, 492);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Meat Boy Stats";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.cmsChapters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvLevels)).EndInit();
            this.cmsLevels.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.cmsStats.ResumeLayout(false);
            this.cmsCompare.ResumeLayout(false);
            this.tcStats.ResumeLayout(false);
            this.tpTotalStats.ResumeLayout(false);
            this.tpChapterStats.ResumeLayout(false);
            this.cmsChapterStats.ResumeLayout(false);
            this.tpCharacters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvCharacters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        private HelpersLibrary.MyListView lvChapters;
        private System.Windows.Forms.ColumnHeader chChapters;
        private System.Windows.Forms.ColumnHeader chLight;
        private System.Windows.Forms.ColumnHeader chDark;
        private System.Windows.Forms.ColumnHeader chBandage;
        private System.Windows.Forms.ColumnHeader chWarp;
        private System.Windows.Forms.ColumnHeader chProgress;
        private BrightIdeasSoftware.ObjectListView olvLevels;
        private BrightIdeasSoftware.OLVColumn olvColumnLevels;
        private BrightIdeasSoftware.OLVColumn olvColumnTime;
        private BrightIdeasSoftware.OLVColumn olvColumnParTime;
        private BrightIdeasSoftware.OLVColumn olvColumnGradeA;
        private BrightIdeasSoftware.OLVColumn olvColumnBandage;
        private BrightIdeasSoftware.OLVColumn olvColumnWarp;
        private System.Windows.Forms.ComboBox cbLevelType;
        private System.Windows.Forms.Label lblLevelType;
        private System.Windows.Forms.ContextMenuStrip cmsChapters;
        private System.Windows.Forms.ToolStripMenuItem tsmiChaptersCopy;
        private System.Windows.Forms.ContextMenuStrip cmsLevels;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevelsCopy;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripButton tsbCopyAll;
        private System.Windows.Forms.ToolStripButton tsbCopySelected;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.Button btnNextType;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private HelpersLibrary.MyListView lvStats;
        private System.Windows.Forms.ColumnHeader chStatsName;
        private System.Windows.Forms.ColumnHeader chStatsValue;
        private System.Windows.Forms.ContextMenuStrip cmsStats;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatsCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatsCopyAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevelsCopyAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiChaptersCopyAll;
        private HelpersLibrary.MyListView lvCompare;
        private System.Windows.Forms.ColumnHeader chCompareLevelName;
        private System.Windows.Forms.ColumnHeader chCompareTime1;
        private System.Windows.Forms.ColumnHeader chCompareTime2;
        private System.Windows.Forms.ColumnHeader chCompareDifference;
        private System.Windows.Forms.ColumnHeader chCompareParTime;
        private System.Windows.Forms.CheckBox cbCompare;
        private System.Windows.Forms.ContextMenuStrip cmsCompare;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompareCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompareCopyAll;
        private System.Windows.Forms.ComboBox cbCompareFilter;
        private System.Windows.Forms.TabControl tcStats;
        private System.Windows.Forms.TabPage tpTotalStats;
        private System.Windows.Forms.TabPage tpChapterStats;
        private HelpersLibrary.MyListView lvChapterStats;
        private System.Windows.Forms.ColumnHeader chChapterStatsName;
        private System.Windows.Forms.ColumnHeader chChapterStatsValue;
        private System.Windows.Forms.ContextMenuStrip cmsChapterStats;
        private System.Windows.Forms.ToolStripMenuItem tsmiChapterStatsCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiChapterStatsCopyAll;
        private System.Windows.Forms.TabPage tpCharacters;
        private BrightIdeasSoftware.ObjectListView olvCharacters;
        private BrightIdeasSoftware.OLVColumn olvColumnCharactersName;
        private BrightIdeasSoftware.OLVColumn olvColumnCharactersRequirement;
        private BrightIdeasSoftware.OLVColumn olvColumnCharactersStatus;
        private BrightIdeasSoftware.OLVColumn olvColumnCharactersWhere;
        private System.Windows.Forms.ToolStripSeparator tsmiLevelsSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevelsLeaderboard;
        private System.Windows.Forms.ToolStripButton tsbLeaderboard;
        private System.Windows.Forms.ToolStripButton tsbUnpackData;
    }
}