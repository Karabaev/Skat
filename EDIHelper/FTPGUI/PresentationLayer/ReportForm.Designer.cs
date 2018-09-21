namespace FTPGui.PresentationLayer
{
    partial class ReportForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.P1ClientTbl = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.P1WaybillTbl = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.P1TotalWbTxt = new System.Windows.Forms.TextBox();
            this.P1TotalRoamWbTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P1ClientTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1WaybillTbl)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 564);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.P1TotalRoamWbTxt);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.P1TotalWbTxt);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.P1WaybillTbl);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.P1ClientTbl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // P1ClientTbl
            // 
            this.P1ClientTbl.AllowUserToAddRows = false;
            this.P1ClientTbl.AllowUserToDeleteRows = false;
            this.P1ClientTbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.P1ClientTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.P1ClientTbl.Location = new System.Drawing.Point(6, 20);
            this.P1ClientTbl.Name = "P1ClientTbl";
            this.P1ClientTbl.ReadOnly = true;
            this.P1ClientTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.P1ClientTbl.Size = new System.Drawing.Size(524, 122);
            this.P1ClientTbl.TabIndex = 0;
            this.P1ClientTbl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.P1ClientTbl_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select client:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Waybills:";
            // 
            // P1WaybillTbl
            // 
            this.P1WaybillTbl.AllowUserToAddRows = false;
            this.P1WaybillTbl.AllowUserToDeleteRows = false;
            this.P1WaybillTbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.P1WaybillTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.P1WaybillTbl.Location = new System.Drawing.Point(9, 161);
            this.P1WaybillTbl.Name = "P1WaybillTbl";
            this.P1WaybillTbl.ReadOnly = true;
            this.P1WaybillTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.P1WaybillTbl.Size = new System.Drawing.Size(524, 367);
            this.P1WaybillTbl.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total waybills:";
            // 
            // P1TotalWbTxt
            // 
            this.P1TotalWbTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.P1TotalWbTxt.Enabled = false;
            this.P1TotalWbTxt.Location = new System.Drawing.Point(662, 489);
            this.P1TotalWbTxt.Name = "P1TotalWbTxt";
            this.P1TotalWbTxt.Size = new System.Drawing.Size(100, 20);
            this.P1TotalWbTxt.TabIndex = 5;
            // 
            // P1TotalRoamWbTxt
            // 
            this.P1TotalRoamWbTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.P1TotalRoamWbTxt.Enabled = false;
            this.P1TotalRoamWbTxt.Location = new System.Drawing.Point(662, 512);
            this.P1TotalRoamWbTxt.Name = "P1TotalRoamWbTxt";
            this.P1TotalRoamWbTxt.Size = new System.Drawing.Size(100, 20);
            this.P1TotalRoamWbTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 515);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total roaming waybills:";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 588);
            this.Controls.Add(this.tabControl1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P1ClientTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1WaybillTbl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView P1ClientTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView P1WaybillTbl;
        private System.Windows.Forms.TextBox P1TotalWbTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox P1TotalRoamWbTxt;
        private System.Windows.Forms.Label label4;
    }
}