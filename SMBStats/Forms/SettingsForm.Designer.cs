namespace SMBStats
{
    partial class SettingsForm
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
            this.cbAutoLoad = new System.Windows.Forms.CheckBox();
            this.lblSteamIDInfo = new System.Windows.Forms.Label();
            this.txtSteamID = new System.Windows.Forms.TextBox();
            this.btnSteamIDApply = new System.Windows.Forms.Button();
            this.lblSteamID = new System.Windows.Forms.Label();
            this.gbOnStartup = new System.Windows.Forms.GroupBox();
            this.cbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.gbLeaderboard = new System.Windows.Forms.GroupBox();
            this.gbOnStartup.SuspendLayout();
            this.gbLeaderboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAutoLoad
            // 
            this.cbAutoLoad.AutoSize = true;
            this.cbAutoLoad.Location = new System.Drawing.Point(16, 24);
            this.cbAutoLoad.Name = "cbAutoLoad";
            this.cbAutoLoad.Size = new System.Drawing.Size(158, 17);
            this.cbAutoLoad.TabIndex = 0;
            this.cbAutoLoad.Text = "Auto load last savegame file";
            this.cbAutoLoad.UseVisualStyleBackColor = true;
            this.cbAutoLoad.CheckedChanged += new System.EventHandler(this.cbAutoLoad_CheckedChanged);
            // 
            // lblSteamIDInfo
            // 
            this.lblSteamIDInfo.AutoSize = true;
            this.lblSteamIDInfo.Location = new System.Drawing.Point(16, 24);
            this.lblSteamIDInfo.Name = "lblSteamIDInfo";
            this.lblSteamIDInfo.Size = new System.Drawing.Size(289, 13);
            this.lblSteamIDInfo.TabIndex = 1;
            this.lblSteamIDInfo.Text = "Steam ID / Friend ID / Community ID / Community URL etc:";
            // 
            // txtSteamID
            // 
            this.txtSteamID.Location = new System.Drawing.Point(18, 49);
            this.txtSteamID.Name = "txtSteamID";
            this.txtSteamID.Size = new System.Drawing.Size(200, 20);
            this.txtSteamID.TabIndex = 2;
            // 
            // btnSteamIDApply
            // 
            this.btnSteamIDApply.Location = new System.Drawing.Point(226, 48);
            this.btnSteamIDApply.Name = "btnSteamIDApply";
            this.btnSteamIDApply.Size = new System.Drawing.Size(75, 23);
            this.btnSteamIDApply.TabIndex = 3;
            this.btnSteamIDApply.Text = "Apply";
            this.btnSteamIDApply.UseVisualStyleBackColor = true;
            this.btnSteamIDApply.Click += new System.EventHandler(this.btnSteamIDApply_Click);
            // 
            // lblSteamID
            // 
            this.lblSteamID.AutoSize = true;
            this.lblSteamID.Location = new System.Drawing.Point(16, 80);
            this.lblSteamID.Name = "lblSteamID";
            this.lblSteamID.Size = new System.Drawing.Size(73, 13);
            this.lblSteamID.TabIndex = 4;
            this.lblSteamID.Text = "Steam ID is: 0";
            // 
            // gbOnStartup
            // 
            this.gbOnStartup.Controls.Add(this.cbAutoUpdate);
            this.gbOnStartup.Controls.Add(this.cbAutoLoad);
            this.gbOnStartup.Location = new System.Drawing.Point(8, 8);
            this.gbOnStartup.Name = "gbOnStartup";
            this.gbOnStartup.Size = new System.Drawing.Size(320, 80);
            this.gbOnStartup.TabIndex = 5;
            this.gbOnStartup.TabStop = false;
            this.gbOnStartup.Text = "On startup";
            // 
            // cbAutoUpdate
            // 
            this.cbAutoUpdate.AutoSize = true;
            this.cbAutoUpdate.Location = new System.Drawing.Point(16, 51);
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.Size = new System.Drawing.Size(117, 17);
            this.cbAutoUpdate.TabIndex = 1;
            this.cbAutoUpdate.Text = "Auto check update";
            this.cbAutoUpdate.UseVisualStyleBackColor = true;
            this.cbAutoUpdate.CheckedChanged += new System.EventHandler(this.cbAutoUpdate_CheckedChanged);
            // 
            // gbLeaderboard
            // 
            this.gbLeaderboard.Controls.Add(this.lblSteamIDInfo);
            this.gbLeaderboard.Controls.Add(this.txtSteamID);
            this.gbLeaderboard.Controls.Add(this.lblSteamID);
            this.gbLeaderboard.Controls.Add(this.btnSteamIDApply);
            this.gbLeaderboard.Location = new System.Drawing.Point(8, 96);
            this.gbLeaderboard.Name = "gbLeaderboard";
            this.gbLeaderboard.Size = new System.Drawing.Size(320, 104);
            this.gbLeaderboard.TabIndex = 6;
            this.gbLeaderboard.TabStop = false;
            this.gbLeaderboard.Text = "Steam leaderboard";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 210);
            this.Controls.Add(this.gbLeaderboard);
            this.Controls.Add(this.gbOnStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBStats - Settings";
            this.gbOnStartup.ResumeLayout(false);
            this.gbOnStartup.PerformLayout();
            this.gbLeaderboard.ResumeLayout(false);
            this.gbLeaderboard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.CheckBox cbAutoLoad;
        private System.Windows.Forms.Label lblSteamIDInfo;
        private System.Windows.Forms.TextBox txtSteamID;
        private System.Windows.Forms.Button btnSteamIDApply;
        private System.Windows.Forms.Label lblSteamID;
        private System.Windows.Forms.GroupBox gbOnStartup;
        private System.Windows.Forms.CheckBox cbAutoUpdate;
        private System.Windows.Forms.GroupBox gbLeaderboard;
    }
}