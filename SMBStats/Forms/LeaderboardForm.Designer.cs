namespace SMBStats
{
    partial class LeaderboardForm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.cbLeaderboardFilterType = new System.Windows.Forms.ComboBox();
            this.nudLevelRange = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblLevelRange = new System.Windows.Forms.Label();
            this.cbLeaderboardType = new System.Windows.Forms.ComboBox();
            this.cmsLevelLeaderboard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiLevelLeaderboardOpenCommunity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLevelLeaderboardCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsGlobalLeaderboard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiGlobalLeaderboardOpenCommunity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGlobalLeaderboardCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.lvLevelLeaderboard = new HelpersLibrary.MyListView();
            this.chLevelRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLevelNickname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLevelTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvGlobalLeaderboard = new HelpersLibrary.MyListView();
            this.chGlobalRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGlobalNickname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGlobalTotalTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGlobalLevelsBeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelRange)).BeginInit();
            this.cmsLevelLeaderboard.SuspendLayout();
            this.cmsGlobalLeaderboard.SuspendLayout();
            this.SuspendLayout();
            //
            // lblInfo
            //
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInfo.Location = new System.Drawing.Point(200, 12);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(29, 16);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Info";
            //
            // cbLeaderboardFilterType
            //
            this.cbLeaderboardFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLeaderboardFilterType.FormattingEnabled = true;
            this.cbLeaderboardFilterType.Items.AddRange(new object[] {
            "Friends",
            "Global"});
            this.cbLeaderboardFilterType.Location = new System.Drawing.Point(128, 10);
            this.cbLeaderboardFilterType.Name = "cbLeaderboardFilterType";
            this.cbLeaderboardFilterType.Size = new System.Drawing.Size(64, 21);
            this.cbLeaderboardFilterType.TabIndex = 3;
            this.cbLeaderboardFilterType.SelectedIndexChanged += new System.EventHandler(this.cbLeaderboardFilterType_SelectedIndexChanged);
            //
            // nudLevelRange
            //
            this.nudLevelRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudLevelRange.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudLevelRange.Location = new System.Drawing.Point(8, 368);
            this.nudLevelRange.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLevelRange.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudLevelRange.Name = "nudLevelRange";
            this.nudLevelRange.Size = new System.Drawing.Size(88, 20);
            this.nudLevelRange.TabIndex = 7;
            this.nudLevelRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLevelRange.Value = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLevelRange.ValueChanged += new System.EventHandler(this.nudLevelRange_ValueChanged);
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(104, 367);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // lblLevelRange
            //
            this.lblLevelRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLevelRange.AutoSize = true;
            this.lblLevelRange.Location = new System.Drawing.Point(176, 372);
            this.lblLevelRange.Name = "lblLevelRange";
            this.lblLevelRange.Size = new System.Drawing.Size(39, 13);
            this.lblLevelRange.TabIndex = 9;
            this.lblLevelRange.Text = "Range";
            //
            // cbLeaderboardType
            //
            this.cbLeaderboardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLeaderboardType.FormattingEnabled = true;
            this.cbLeaderboardType.Items.AddRange(new object[] {
            "Global leaderboard",
            "Level leaderboard"});
            this.cbLeaderboardType.Location = new System.Drawing.Point(8, 10);
            this.cbLeaderboardType.Name = "cbLeaderboardType";
            this.cbLeaderboardType.Size = new System.Drawing.Size(112, 21);
            this.cbLeaderboardType.TabIndex = 11;
            this.cbLeaderboardType.SelectedIndexChanged += new System.EventHandler(this.cbLeaderboardType_SelectedIndexChanged);
            //
            // cmsLevelLeaderboard
            //
            this.cmsLevelLeaderboard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLevelLeaderboardOpenCommunity,
            this.tsmiLevelLeaderboardCopy});
            this.cmsLevelLeaderboard.Name = "cmsLevelLeaderboard";
            this.cmsLevelLeaderboard.ShowImageMargin = false;
            this.cmsLevelLeaderboard.Size = new System.Drawing.Size(173, 48);
            //
            // tsmiLevelLeaderboardOpenCommunity
            //
            this.tsmiLevelLeaderboardOpenCommunity.Name = "tsmiLevelLeaderboardOpenCommunity";
            this.tsmiLevelLeaderboardOpenCommunity.Size = new System.Drawing.Size(172, 22);
            this.tsmiLevelLeaderboardOpenCommunity.Text = "Open community page";
            this.tsmiLevelLeaderboardOpenCommunity.Click += new System.EventHandler(this.tsmiLevelLeaderboardOpenCommunity_Click);
            //
            // tsmiLevelLeaderboardCopy
            //
            this.tsmiLevelLeaderboardCopy.Name = "tsmiLevelLeaderboardCopy";
            this.tsmiLevelLeaderboardCopy.Size = new System.Drawing.Size(172, 22);
            this.tsmiLevelLeaderboardCopy.Text = "Copy";
            this.tsmiLevelLeaderboardCopy.Click += new System.EventHandler(this.tsmiLevelLeaderboardCopy_Click);
            //
            // cmsGlobalLeaderboard
            //
            this.cmsGlobalLeaderboard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGlobalLeaderboardOpenCommunity,
            this.tsmiGlobalLeaderboardCopy});
            this.cmsGlobalLeaderboard.Name = "cmsGlobalLeaderboard";
            this.cmsGlobalLeaderboard.ShowImageMargin = false;
            this.cmsGlobalLeaderboard.Size = new System.Drawing.Size(173, 48);
            //
            // tsmiGlobalLeaderboardOpenCommunity
            //
            this.tsmiGlobalLeaderboardOpenCommunity.Name = "tsmiGlobalLeaderboardOpenCommunity";
            this.tsmiGlobalLeaderboardOpenCommunity.Size = new System.Drawing.Size(172, 22);
            this.tsmiGlobalLeaderboardOpenCommunity.Text = "Open community page";
            this.tsmiGlobalLeaderboardOpenCommunity.Click += new System.EventHandler(this.tsmiGlobalLeaderboardOpenCommunity_Click);
            //
            // tsmiGlobalLeaderboardCopy
            //
            this.tsmiGlobalLeaderboardCopy.Name = "tsmiGlobalLeaderboardCopy";
            this.tsmiGlobalLeaderboardCopy.Size = new System.Drawing.Size(172, 22);
            this.tsmiGlobalLeaderboardCopy.Text = "Copy";
            this.tsmiGlobalLeaderboardCopy.Click += new System.EventHandler(this.tsmiGlobalLeaderboardCopy_Click);
            //
            // lvLevelLeaderboard
            //
            this.lvLevelLeaderboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLevelLeaderboard.AutoFillColumn = true;
            this.lvLevelLeaderboard.AutoFillColumnIndex = 1;
            this.lvLevelLeaderboard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLevelRank,
            this.chLevelNickname,
            this.chLevelTime});
            this.lvLevelLeaderboard.ContextMenuStrip = this.cmsLevelLeaderboard;
            this.lvLevelLeaderboard.FullRowSelect = true;
            this.lvLevelLeaderboard.GridLines = true;
            this.lvLevelLeaderboard.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLevelLeaderboard.Location = new System.Drawing.Point(8, 40);
            this.lvLevelLeaderboard.MultiSelect = false;
            this.lvLevelLeaderboard.Name = "lvLevelLeaderboard";
            this.lvLevelLeaderboard.Size = new System.Drawing.Size(384, 320);
            this.lvLevelLeaderboard.TabIndex = 2;
            this.lvLevelLeaderboard.UseCompatibleStateImageBehavior = false;
            this.lvLevelLeaderboard.View = System.Windows.Forms.View.Details;
            //
            // chLevelRank
            //
            this.chLevelRank.Text = "Rank";
            this.chLevelRank.Width = 75;
            //
            // chLevelNickname
            //
            this.chLevelNickname.Text = "Nickname";
            this.chLevelNickname.Width = 150;
            //
            // chLevelTime
            //
            this.chLevelTime.Text = "Time";
            this.chLevelTime.Width = 75;
            //
            // lvGlobalLeaderboard
            //
            this.lvGlobalLeaderboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGlobalLeaderboard.AutoFillColumn = true;
            this.lvGlobalLeaderboard.AutoFillColumnIndex = 1;
            this.lvGlobalLeaderboard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chGlobalRank,
            this.chGlobalNickname,
            this.chGlobalTotalTime,
            this.chGlobalLevelsBeat});
            this.lvGlobalLeaderboard.ContextMenuStrip = this.cmsGlobalLeaderboard;
            this.lvGlobalLeaderboard.FullRowSelect = true;
            this.lvGlobalLeaderboard.GridLines = true;
            this.lvGlobalLeaderboard.Location = new System.Drawing.Point(8, 40);
            this.lvGlobalLeaderboard.MultiSelect = false;
            this.lvGlobalLeaderboard.Name = "lvGlobalLeaderboard";
            this.lvGlobalLeaderboard.Size = new System.Drawing.Size(384, 320);
            this.lvGlobalLeaderboard.TabIndex = 10;
            this.lvGlobalLeaderboard.UseCompatibleStateImageBehavior = false;
            this.lvGlobalLeaderboard.View = System.Windows.Forms.View.Details;
            //
            // chGlobalRank
            //
            this.chGlobalRank.Text = "Rank";
            //
            // chGlobalNickname
            //
            this.chGlobalNickname.Text = "Nickname";
            this.chGlobalNickname.Width = 125;
            //
            // chGlobalTotalTime
            //
            this.chGlobalTotalTime.Text = "Total time";
            this.chGlobalTotalTime.Width = 75;
            //
            // chGlobalLevelsBeat
            //
            this.chGlobalLevelsBeat.Text = "Levels beat";
            this.chGlobalLevelsBeat.Width = 75;
            //
            // LeaderboardForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 398);
            this.Controls.Add(this.cbLeaderboardType);
            this.Controls.Add(this.lblLevelRange);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.nudLevelRange);
            this.Controls.Add(this.cbLeaderboardFilterType);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lvGlobalLeaderboard);
            this.Controls.Add(this.lvLevelLeaderboard);
            this.MaximizeBox = false;
            this.Name = "LeaderboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBStats - Leaderboard";
            this.Shown += new System.EventHandler(this.LeaderboardForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelRange)).EndInit();
            this.cmsLevelLeaderboard.ResumeLayout(false);
            this.cmsGlobalLeaderboard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.Label lblInfo;
        private HelpersLibrary.MyListView lvLevelLeaderboard;
        private System.Windows.Forms.ColumnHeader chLevelRank;
        private System.Windows.Forms.ColumnHeader chLevelNickname;
        private System.Windows.Forms.ColumnHeader chLevelTime;
        private System.Windows.Forms.ComboBox cbLeaderboardFilterType;
        private System.Windows.Forms.NumericUpDown nudLevelRange;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblLevelRange;
        private HelpersLibrary.MyListView lvGlobalLeaderboard;
        private System.Windows.Forms.ColumnHeader chGlobalRank;
        private System.Windows.Forms.ColumnHeader chGlobalNickname;
        private System.Windows.Forms.ColumnHeader chGlobalTotalTime;
        private System.Windows.Forms.ColumnHeader chGlobalLevelsBeat;
        private System.Windows.Forms.ComboBox cbLeaderboardType;
        private System.Windows.Forms.ContextMenuStrip cmsLevelLeaderboard;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevelLeaderboardOpenCommunity;
        private System.Windows.Forms.ToolStripMenuItem tsmiLevelLeaderboardCopy;
        private System.Windows.Forms.ContextMenuStrip cmsGlobalLeaderboard;
        private System.Windows.Forms.ToolStripMenuItem tsmiGlobalLeaderboardOpenCommunity;
        private System.Windows.Forms.ToolStripMenuItem tsmiGlobalLeaderboardCopy;
    }
}