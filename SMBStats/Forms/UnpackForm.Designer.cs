namespace SMBStats
{
    partial class UnpackForm
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
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.btnBrowseData = new System.Windows.Forms.Button();
            this.btnBrowseExtract = new System.Windows.Forms.Button();
            this.txtExtractPath = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.lblDataFile = new System.Windows.Forms.Label();
            this.lblExtractPath = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnOpenResult = new System.Windows.Forms.Button();
            this.cbAutoConvert = new System.Windows.Forms.CheckBox();
            this.tcUnpack = new System.Windows.Forms.TabControl();
            this.tpUnpack = new System.Windows.Forms.TabPage();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.btnConvertTPtoPNG = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvertPNGtoTP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateEmptyData = new System.Windows.Forms.Button();
            this.tcUnpack.SuspendLayout();
            this.tpUnpack.SuspendLayout();
            this.tpOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(88, 12);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(304, 20);
            this.txtDataPath.TabIndex = 0;
            // 
            // btnBrowseData
            // 
            this.btnBrowseData.Location = new System.Drawing.Point(400, 11);
            this.btnBrowseData.Name = "btnBrowseData";
            this.btnBrowseData.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseData.TabIndex = 1;
            this.btnBrowseData.Text = "Browse...";
            this.btnBrowseData.UseVisualStyleBackColor = true;
            this.btnBrowseData.Click += new System.EventHandler(this.btnBrowseData_Click);
            // 
            // btnBrowseExtract
            // 
            this.btnBrowseExtract.Location = new System.Drawing.Point(400, 43);
            this.btnBrowseExtract.Name = "btnBrowseExtract";
            this.btnBrowseExtract.Size = new System.Drawing.Size(80, 23);
            this.btnBrowseExtract.TabIndex = 2;
            this.btnBrowseExtract.Text = "Browse...";
            this.btnBrowseExtract.UseVisualStyleBackColor = true;
            this.btnBrowseExtract.Click += new System.EventHandler(this.btnBrowseExtract_Click);
            // 
            // txtExtractPath
            // 
            this.txtExtractPath.Location = new System.Drawing.Point(88, 44);
            this.txtExtractPath.Name = "txtExtractPath";
            this.txtExtractPath.Size = new System.Drawing.Size(304, 20);
            this.txtExtractPath.TabIndex = 3;
            // 
            // btnExtract
            // 
            this.btnExtract.Enabled = false;
            this.btnExtract.Location = new System.Drawing.Point(400, 75);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(80, 23);
            this.btnExtract.TabIndex = 4;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // lblDataFile
            // 
            this.lblDataFile.AutoSize = true;
            this.lblDataFile.Location = new System.Drawing.Point(8, 16);
            this.lblDataFile.Name = "lblDataFile";
            this.lblDataFile.Size = new System.Drawing.Size(49, 13);
            this.lblDataFile.TabIndex = 5;
            this.lblDataFile.Text = "Data file:";
            // 
            // lblExtractPath
            // 
            this.lblExtractPath.AutoSize = true;
            this.lblExtractPath.Location = new System.Drawing.Point(8, 48);
            this.lblExtractPath.Name = "lblExtractPath";
            this.lblExtractPath.Size = new System.Drawing.Size(72, 13);
            this.lblExtractPath.TabIndex = 6;
            this.lblExtractPath.Text = "Extract folder:";
            // 
            // lblDestination
            // 
            this.lblDestination.Location = new System.Drawing.Point(8, 101);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(384, 40);
            this.lblDestination.TabIndex = 7;
            this.lblDestination.Text = "Extract path:";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(8, 166);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(472, 24);
            this.pbProgress.TabIndex = 8;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(8, 147);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(51, 13);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "Progress:";
            // 
            // btnOpenResult
            // 
            this.btnOpenResult.Enabled = false;
            this.btnOpenResult.Location = new System.Drawing.Point(400, 107);
            this.btnOpenResult.Name = "btnOpenResult";
            this.btnOpenResult.Size = new System.Drawing.Size(80, 23);
            this.btnOpenResult.TabIndex = 10;
            this.btnOpenResult.Text = "Open folder";
            this.btnOpenResult.UseVisualStyleBackColor = true;
            this.btnOpenResult.Click += new System.EventHandler(this.btnOpenResult_Click);
            // 
            // cbAutoConvert
            // 
            this.cbAutoConvert.AutoSize = true;
            this.cbAutoConvert.Checked = true;
            this.cbAutoConvert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoConvert.Location = new System.Drawing.Point(11, 75);
            this.cbAutoConvert.Name = "cbAutoConvert";
            this.cbAutoConvert.Size = new System.Drawing.Size(163, 17);
            this.cbAutoConvert.TabIndex = 11;
            this.cbAutoConvert.Text = "Auto convert TP files to PNG";
            this.cbAutoConvert.UseVisualStyleBackColor = true;
            // 
            // tcUnpack
            // 
            this.tcUnpack.Controls.Add(this.tpUnpack);
            this.tcUnpack.Controls.Add(this.tpOther);
            this.tcUnpack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUnpack.Location = new System.Drawing.Point(3, 3);
            this.tcUnpack.Name = "tcUnpack";
            this.tcUnpack.SelectedIndex = 0;
            this.tcUnpack.Size = new System.Drawing.Size(500, 225);
            this.tcUnpack.TabIndex = 12;
            // 
            // tpUnpack
            // 
            this.tpUnpack.Controls.Add(this.lblDataFile);
            this.tpUnpack.Controls.Add(this.cbAutoConvert);
            this.tpUnpack.Controls.Add(this.txtDataPath);
            this.tpUnpack.Controls.Add(this.btnOpenResult);
            this.tpUnpack.Controls.Add(this.btnBrowseData);
            this.tpUnpack.Controls.Add(this.lblProgress);
            this.tpUnpack.Controls.Add(this.btnBrowseExtract);
            this.tpUnpack.Controls.Add(this.pbProgress);
            this.tpUnpack.Controls.Add(this.txtExtractPath);
            this.tpUnpack.Controls.Add(this.lblDestination);
            this.tpUnpack.Controls.Add(this.btnExtract);
            this.tpUnpack.Controls.Add(this.lblExtractPath);
            this.tpUnpack.Location = new System.Drawing.Point(4, 22);
            this.tpUnpack.Name = "tpUnpack";
            this.tpUnpack.Padding = new System.Windows.Forms.Padding(3);
            this.tpUnpack.Size = new System.Drawing.Size(492, 199);
            this.tpUnpack.TabIndex = 0;
            this.tpUnpack.Text = "Unpack";
            this.tpUnpack.UseVisualStyleBackColor = true;
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.btnConvertTPtoPNG);
            this.tpOther.Controls.Add(this.label3);
            this.tpOther.Controls.Add(this.btnConvertPNGtoTP);
            this.tpOther.Controls.Add(this.label2);
            this.tpOther.Controls.Add(this.label1);
            this.tpOther.Controls.Add(this.btnCreateEmptyData);
            this.tpOther.Location = new System.Drawing.Point(4, 22);
            this.tpOther.Name = "tpOther";
            this.tpOther.Padding = new System.Windows.Forms.Padding(3);
            this.tpOther.Size = new System.Drawing.Size(492, 199);
            this.tpOther.TabIndex = 1;
            this.tpOther.Text = "Advanced";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // btnConvertTPtoPNG
            // 
            this.btnConvertTPtoPNG.Location = new System.Drawing.Point(152, 80);
            this.btnConvertTPtoPNG.Name = "btnConvertTPtoPNG";
            this.btnConvertTPtoPNG.Size = new System.Drawing.Size(160, 23);
            this.btnConvertTPtoPNG.TabIndex = 5;
            this.btnConvertTPtoPNG.Text = "Select TP file...";
            this.btnConvertTPtoPNG.UseVisualStyleBackColor = true;
            this.btnConvertTPtoPNG.Click += new System.EventHandler(this.btnConvertTPtoPNG_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Convert TP file to PNG:";
            // 
            // btnConvertPNGtoTP
            // 
            this.btnConvertPNGtoTP.Location = new System.Drawing.Point(152, 48);
            this.btnConvertPNGtoTP.Name = "btnConvertPNGtoTP";
            this.btnConvertPNGtoTP.Size = new System.Drawing.Size(160, 23);
            this.btnConvertPNGtoTP.TabIndex = 3;
            this.btnConvertPNGtoTP.Text = "Select PNG file...";
            this.btnConvertPNGtoTP.UseVisualStyleBackColor = true;
            this.btnConvertPNGtoTP.Click += new System.EventHandler(this.btnConvertPNGtoTP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Convert PNG file to TP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create empty data file:";
            // 
            // btnCreateEmptyData
            // 
            this.btnCreateEmptyData.Location = new System.Drawing.Point(152, 16);
            this.btnCreateEmptyData.Name = "btnCreateEmptyData";
            this.btnCreateEmptyData.Size = new System.Drawing.Size(160, 23);
            this.btnCreateEmptyData.TabIndex = 0;
            this.btnCreateEmptyData.Text = "Select where to create...";
            this.btnCreateEmptyData.UseVisualStyleBackColor = true;
            this.btnCreateEmptyData.Click += new System.EventHandler(this.btnCreateEmptyData_Click);
            // 
            // UnpackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 231);
            this.Controls.Add(this.tcUnpack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UnpackForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBStats - Unpack data";
            this.Resize += new System.EventHandler(this.UnpackForm_Resize);
            this.tcUnpack.ResumeLayout(false);
            this.tpUnpack.ResumeLayout(false);
            this.tpUnpack.PerformLayout();
            this.tpOther.ResumeLayout(false);
            this.tpOther.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.Button btnBrowseData;
        private System.Windows.Forms.Button btnBrowseExtract;
        private System.Windows.Forms.TextBox txtExtractPath;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Label lblDataFile;
        private System.Windows.Forms.Label lblExtractPath;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnOpenResult;
        private System.Windows.Forms.CheckBox cbAutoConvert;
        private System.Windows.Forms.TabControl tcUnpack;
        private System.Windows.Forms.TabPage tpUnpack;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.Button btnConvertTPtoPNG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvertPNGtoTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateEmptyData;
    }
}