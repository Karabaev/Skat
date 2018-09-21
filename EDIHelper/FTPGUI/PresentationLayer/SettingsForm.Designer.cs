namespace FTPGui.PresentationLayer
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
            this.CloseBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.WBFolderTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FtpUriTxt = new System.Windows.Forms.TextBox();
            this.CloseWithoutSaveBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.IntervalTxt = new System.Windows.Forms.MaskedTextBox();
            this.PassiveChk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ServiceNameTxt = new System.Windows.Forms.TextBox();
            this.FtpTimeoutTxt = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(261, 188);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(97, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Save and close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // WBFolderTxt
            // 
            this.WBFolderTxt.Location = new System.Drawing.Point(166, 38);
            this.WBFolderTxt.Name = "WBFolderTxt";
            this.WBFolderTxt.Size = new System.Drawing.Size(312, 20);
            this.WBFolderTxt.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Waybill folder on FTP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ftp URI:";
            // 
            // FtpUriTxt
            // 
            this.FtpUriTxt.Location = new System.Drawing.Point(166, 12);
            this.FtpUriTxt.Name = "FtpUriTxt";
            this.FtpUriTxt.Size = new System.Drawing.Size(312, 20);
            this.FtpUriTxt.TabIndex = 11;
            // 
            // CloseWithoutSaveBtn
            // 
            this.CloseWithoutSaveBtn.Location = new System.Drawing.Point(364, 188);
            this.CloseWithoutSaveBtn.Name = "CloseWithoutSaveBtn";
            this.CloseWithoutSaveBtn.Size = new System.Drawing.Size(114, 23);
            this.CloseWithoutSaveBtn.TabIndex = 13;
            this.CloseWithoutSaveBtn.Text = "Close without save";
            this.CloseWithoutSaveBtn.UseVisualStyleBackColor = true;
            this.CloseWithoutSaveBtn.Click += new System.EventHandler(this.CloseWithoutSaveBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Download Interval, sec:";
            // 
            // IntervalTxt
            // 
            this.IntervalTxt.Location = new System.Drawing.Point(166, 67);
            this.IntervalTxt.Mask = "0000000";
            this.IntervalTxt.Name = "IntervalTxt";
            this.IntervalTxt.Size = new System.Drawing.Size(312, 20);
            this.IntervalTxt.TabIndex = 16;
            // 
            // PassiveChk
            // 
            this.PassiveChk.AutoSize = true;
            this.PassiveChk.Location = new System.Drawing.Point(166, 119);
            this.PassiveChk.Name = "PassiveChk";
            this.PassiveChk.Size = new System.Drawing.Size(86, 17);
            this.PassiveChk.TabIndex = 17;
            this.PassiveChk.Text = "Passive FTP";
            this.PassiveChk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Service name:";
            // 
            // ServiceNameTxt
            // 
            this.ServiceNameTxt.Location = new System.Drawing.Point(166, 142);
            this.ServiceNameTxt.Name = "ServiceNameTxt";
            this.ServiceNameTxt.Size = new System.Drawing.Size(312, 20);
            this.ServiceNameTxt.TabIndex = 18;
            // 
            // FtpTimeoutTxt
            // 
            this.FtpTimeoutTxt.Location = new System.Drawing.Point(166, 93);
            this.FtpTimeoutTxt.Mask = "00";
            this.FtpTimeoutTxt.Name = "FtpTimeoutTxt";
            this.FtpTimeoutTxt.Size = new System.Drawing.Size(312, 20);
            this.FtpTimeoutTxt.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "FTP timeout, sec:";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.CloseBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 223);
            this.Controls.Add(this.FtpTimeoutTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServiceNameTxt);
            this.Controls.Add(this.PassiveChk);
            this.Controls.Add(this.IntervalTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CloseWithoutSaveBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FtpUriTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WBFolderTxt);
            this.Controls.Add(this.CloseBtn);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox WBFolderTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FtpUriTxt;
        private System.Windows.Forms.Button CloseWithoutSaveBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox IntervalTxt;
        private System.Windows.Forms.CheckBox PassiveChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServiceNameTxt;
        private System.Windows.Forms.MaskedTextBox FtpTimeoutTxt;
        private System.Windows.Forms.Label label2;
    }
}