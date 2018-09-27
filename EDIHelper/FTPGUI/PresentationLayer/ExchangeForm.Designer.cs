namespace FTPGui.PresentationLayer
{
    partial class ExchangeForm
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
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.UnloadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Location = new System.Drawing.Point(12, 12);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(75, 23);
            this.DownloadBtn.TabIndex = 0;
            this.DownloadBtn.Text = "Download";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // UnloadBtn
            // 
            this.UnloadBtn.Location = new System.Drawing.Point(339, 71);
            this.UnloadBtn.Name = "UnloadBtn";
            this.UnloadBtn.Size = new System.Drawing.Size(75, 23);
            this.UnloadBtn.TabIndex = 1;
            this.UnloadBtn.Text = "Unload";
            this.UnloadBtn.UseVisualStyleBackColor = true;
            this.UnloadBtn.Click += new System.EventHandler(this.UnloadBtn_Click);
            // 
            // ExchangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 106);
            this.Controls.Add(this.UnloadBtn);
            this.Controls.Add(this.DownloadBtn);
            this.Name = "ExchangeForm";
            this.Text = "Exchange";
            this.Load += new System.EventHandler(this.ExchangeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Button UnloadBtn;
    }
}