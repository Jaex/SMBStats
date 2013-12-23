namespace SMBStats
{
    partial class AboutForm
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
            this.lblJuzz = new System.Windows.Forms.Label();
            this.lblTeamMeat = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblJuzz
            // 
            this.lblJuzz.AutoSize = true;
            this.lblJuzz.BackColor = System.Drawing.Color.Transparent;
            this.lblJuzz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblJuzz.ForeColor = System.Drawing.Color.White;
            this.lblJuzz.Location = new System.Drawing.Point(8, 48);
            this.lblJuzz.Name = "lblJuzz";
            this.lblJuzz.Size = new System.Drawing.Size(173, 26);
            this.lblJuzz.TabIndex = 0;
            this.lblJuzz.Text = "Programmed by: Juzz\r\nhttp://steamcommunity.com/id/ww";
            this.lblJuzz.UseMnemonic = false;
            this.lblJuzz.Click += new System.EventHandler(this.lblJuzz_Click);
            // 
            // lblTeamMeat
            // 
            this.lblTeamMeat.AutoSize = true;
            this.lblTeamMeat.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamMeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTeamMeat.ForeColor = System.Drawing.Color.White;
            this.lblTeamMeat.Location = new System.Drawing.Point(8, 135);
            this.lblTeamMeat.Name = "lblTeamMeat";
            this.lblTeamMeat.Size = new System.Drawing.Size(256, 26);
            this.lblTeamMeat.TabIndex = 1;
            this.lblTeamMeat.Text = "Super Meat Boy: Edmund McMillen, Tommy Refenes\r\nhttp://supermeatboy.com";
            this.lblTeamMeat.UseMnemonic = false;
            this.lblTeamMeat.Click += new System.EventHandler(this.lblTeamMeat_Click);
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.BackColor = System.Drawing.Color.Transparent;
            this.lblCredits.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCredits.ForeColor = System.Drawing.Color.White;
            this.lblCredits.Location = new System.Drawing.Point(8, 85);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(218, 39);
            this.lblCredits.TabIndex = 2;
            this.lblCredits.Text = "Thanks to Roboticaust and Zarkith for helps.\r\nMenu icons: Yusuke Kamiyamane\r\nObje" +
    "ctListView: Phillip Piper";
            this.lblCredits.UseMnemonic = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(8, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 32);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Super Meat Boy Stats";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(306, 173);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.lblTeamMeat);
            this.Controls.Add(this.lblJuzz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBStats - About";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AboutForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.Label lblJuzz;
        private System.Windows.Forms.Label lblTeamMeat;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblTitle;
    }
}