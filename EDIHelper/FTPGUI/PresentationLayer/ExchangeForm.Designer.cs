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
            this.BeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FullUnloadChk = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Location = new System.Drawing.Point(217, 127);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(75, 23);
            this.DownloadBtn.TabIndex = 0;
            this.DownloadBtn.Text = "Загрузить";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // UnloadBtn
            // 
            this.UnloadBtn.Location = new System.Drawing.Point(217, 127);
            this.UnloadBtn.Name = "UnloadBtn";
            this.UnloadBtn.Size = new System.Drawing.Size(75, 23);
            this.UnloadBtn.TabIndex = 1;
            this.UnloadBtn.Text = "Выгрузить";
            this.UnloadBtn.UseVisualStyleBackColor = true;
            this.UnloadBtn.Click += new System.EventHandler(this.UnloadBtn_Click);
            // 
            // BeginDate
            // 
            this.BeginDate.Location = new System.Drawing.Point(104, 14);
            this.BeginDate.Name = "BeginDate";
            this.BeginDate.Size = new System.Drawing.Size(121, 20);
            this.BeginDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Начало периода:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.UnloadBtn);
            this.groupBox1.Controls.Add(this.FullUnloadChk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EndDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BeginDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 156);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выгрузка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Конец периода:";
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(104, 42);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(121, 20);
            this.EndDate.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.Controls.Add(this.DownloadBtn);
            this.groupBox2.Location = new System.Drawing.Point(441, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 156);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Загрузка";
            // 
            // FullUnloadChk
            // 
            this.FullUnloadChk.AutoSize = true;
            this.FullUnloadChk.Location = new System.Drawing.Point(6, 68);
            this.FullUnloadChk.Name = "FullUnloadChk";
            this.FullUnloadChk.Size = new System.Drawing.Size(115, 17);
            this.FullUnloadChk.TabIndex = 7;
            this.FullUnloadChk.Text = "Полная выгрузка";
            this.FullUnloadChk.UseVisualStyleBackColor = true;
            // 
            // ExchangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExchangeForm";
            this.Text = "Exchange";
            this.Load += new System.EventHandler(this.ExchangeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Button UnloadBtn;
        private System.Windows.Forms.DateTimePicker BeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox FullUnloadChk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}