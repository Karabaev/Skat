namespace FTPGui.PresentationLayer
{
    partial class NewMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TOSaveBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TOLocalFolderTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TOFtpPasswordTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TOFtpLoginTxt = new System.Windows.Forms.TextBox();
            this.TORemoveBtn = new System.Windows.Forms.Button();
            this.TOAddNewBtn = new System.Windows.Forms.Button();
            this.TOClientCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TOGlnTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TOAddressTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TONameTxt = new System.Windows.Forms.TextBox();
            this.TradeObjectTbl = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ClientsSaveBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ClientKPPTxt = new System.Windows.Forms.TextBox();
            this.ClientRemoveBtn = new System.Windows.Forms.Button();
            this.ClientAddNewBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ClientINNTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ClientGLNTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ClientNameTxt = new System.Windows.Forms.TextBox();
            this.ClientsTbl = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SuppliersChangeBtn = new System.Windows.Forms.Button();
            this.SupplierRoamingChk = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SupplierKPPTxt = new System.Windows.Forms.TextBox();
            this.SupplierRemoveBtn = new System.Windows.Forms.Button();
            this.SupplierAddNewBtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.SupplierINNTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SupplierGLNTxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SupplierNameTxt = new System.Windows.Forms.TextBox();
            this.SupplierTbl = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.WayBillsTbl = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeObjectTbl)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsTbl)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTbl)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WayBillsTbl)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.exchangeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.settingsToolStripMenuItem.Text = "Натройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reportsToolStripMenuItem.Text = "Отчеты";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // exchangeToolStripMenuItem
            // 
            this.exchangeToolStripMenuItem.Name = "exchangeToolStripMenuItem";
            this.exchangeToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.exchangeToolStripMenuItem.Text = "Обмен";
            this.exchangeToolStripMenuItem.Click += new System.EventHandler(this.exchangeToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 411);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TOSaveBtn);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.TOLocalFolderTxt);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TOFtpPasswordTxt);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.TOFtpLoginTxt);
            this.tabPage1.Controls.Add(this.TORemoveBtn);
            this.tabPage1.Controls.Add(this.TOAddNewBtn);
            this.tabPage1.Controls.Add(this.TOClientCmb);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.TOGlnTxt);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TOAddressTxt);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TONameTxt);
            this.tabPage1.Controls.Add(this.TradeObjectTbl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Торговые объекты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TOSaveBtn
            // 
            this.TOSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOSaveBtn.Location = new System.Drawing.Point(595, 293);
            this.TOSaveBtn.Name = "TOSaveBtn";
            this.TOSaveBtn.Size = new System.Drawing.Size(75, 42);
            this.TOSaveBtn.TabIndex = 18;
            this.TOSaveBtn.Text = "Save changes";
            this.TOSaveBtn.UseVisualStyleBackColor = true;
            this.TOSaveBtn.Click += new System.EventHandler(this.TOSaveBtn_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(595, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Local folder";
            // 
            // TOLocalFolderTxt
            // 
            this.TOLocalFolderTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOLocalFolderTxt.Location = new System.Drawing.Point(595, 226);
            this.TOLocalFolderTxt.Name = "TOLocalFolderTxt";
            this.TOLocalFolderTxt.Size = new System.Drawing.Size(167, 20);
            this.TOLocalFolderTxt.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ftp password";
            // 
            // TOFtpPasswordTxt
            // 
            this.TOFtpPasswordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOFtpPasswordTxt.Location = new System.Drawing.Point(595, 187);
            this.TOFtpPasswordTxt.Name = "TOFtpPasswordTxt";
            this.TOFtpPasswordTxt.Size = new System.Drawing.Size(167, 20);
            this.TOFtpPasswordTxt.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ftp login";
            // 
            // TOFtpLoginTxt
            // 
            this.TOFtpLoginTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOFtpLoginTxt.Location = new System.Drawing.Point(595, 148);
            this.TOFtpLoginTxt.Name = "TOFtpLoginTxt";
            this.TOFtpLoginTxt.Size = new System.Drawing.Size(167, 20);
            this.TOFtpLoginTxt.TabIndex = 12;
            // 
            // TORemoveBtn
            // 
            this.TORemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TORemoveBtn.Location = new System.Drawing.Point(595, 341);
            this.TORemoveBtn.Name = "TORemoveBtn";
            this.TORemoveBtn.Size = new System.Drawing.Size(75, 38);
            this.TORemoveBtn.TabIndex = 11;
            this.TORemoveBtn.Text = "Remove selected";
            this.TORemoveBtn.UseVisualStyleBackColor = true;
            this.TORemoveBtn.Click += new System.EventHandler(this.TORemoveBtn_Click);
            // 
            // TOAddNewBtn
            // 
            this.TOAddNewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOAddNewBtn.Location = new System.Drawing.Point(687, 293);
            this.TOAddNewBtn.Name = "TOAddNewBtn";
            this.TOAddNewBtn.Size = new System.Drawing.Size(75, 23);
            this.TOAddNewBtn.TabIndex = 10;
            this.TOAddNewBtn.Text = "Add new";
            this.TOAddNewBtn.UseVisualStyleBackColor = true;
            this.TOAddNewBtn.Click += new System.EventHandler(this.TOAddNewBtn_Click);
            // 
            // TOClientCmb
            // 
            this.TOClientCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOClientCmb.FormattingEnabled = true;
            this.TOClientCmb.Location = new System.Drawing.Point(598, 266);
            this.TOClientCmb.Name = "TOClientCmb";
            this.TOClientCmb.Size = new System.Drawing.Size(164, 21);
            this.TOClientCmb.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(595, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Client";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(595, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "GLN";
            // 
            // TOGlnTxt
            // 
            this.TOGlnTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOGlnTxt.Location = new System.Drawing.Point(595, 109);
            this.TOGlnTxt.Name = "TOGlnTxt";
            this.TOGlnTxt.Size = new System.Drawing.Size(167, 20);
            this.TOGlnTxt.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address";
            // 
            // TOAddressTxt
            // 
            this.TOAddressTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TOAddressTxt.Location = new System.Drawing.Point(595, 70);
            this.TOAddressTxt.Name = "TOAddressTxt";
            this.TOAddressTxt.Size = new System.Drawing.Size(167, 20);
            this.TOAddressTxt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(595, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // TONameTxt
            // 
            this.TONameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TONameTxt.Location = new System.Drawing.Point(595, 31);
            this.TONameTxt.Name = "TONameTxt";
            this.TONameTxt.Size = new System.Drawing.Size(167, 20);
            this.TONameTxt.TabIndex = 1;
            // 
            // TradeObjectTbl
            // 
            this.TradeObjectTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TradeObjectTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TradeObjectTbl.Location = new System.Drawing.Point(6, 6);
            this.TradeObjectTbl.Name = "TradeObjectTbl";
            this.TradeObjectTbl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.TradeObjectTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TradeObjectTbl.Size = new System.Drawing.Size(583, 373);
            this.TradeObjectTbl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ClientsSaveBtn);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.ClientKPPTxt);
            this.tabPage2.Controls.Add(this.ClientRemoveBtn);
            this.tabPage2.Controls.Add(this.ClientAddNewBtn);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.ClientINNTxt);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.ClientGLNTxt);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.ClientNameTxt);
            this.tabPage2.Controls.Add(this.ClientsTbl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Клиенты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ClientsSaveBtn
            // 
            this.ClientsSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientsSaveBtn.Location = new System.Drawing.Point(598, 283);
            this.ClientsSaveBtn.Name = "ClientsSaveBtn";
            this.ClientsSaveBtn.Size = new System.Drawing.Size(75, 42);
            this.ClientsSaveBtn.TabIndex = 25;
            this.ClientsSaveBtn.Text = "Save changes";
            this.ClientsSaveBtn.UseVisualStyleBackColor = true;
            this.ClientsSaveBtn.Click += new System.EventHandler(this.ClientsSaveBtn_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(595, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "KPP";
            // 
            // ClientKPPTxt
            // 
            this.ClientKPPTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientKPPTxt.Location = new System.Drawing.Point(595, 148);
            this.ClientKPPTxt.Name = "ClientKPPTxt";
            this.ClientKPPTxt.Size = new System.Drawing.Size(167, 20);
            this.ClientKPPTxt.TabIndex = 23;
            // 
            // ClientRemoveBtn
            // 
            this.ClientRemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientRemoveBtn.Location = new System.Drawing.Point(598, 341);
            this.ClientRemoveBtn.Name = "ClientRemoveBtn";
            this.ClientRemoveBtn.Size = new System.Drawing.Size(75, 38);
            this.ClientRemoveBtn.TabIndex = 22;
            this.ClientRemoveBtn.Text = "Remove selected";
            this.ClientRemoveBtn.UseVisualStyleBackColor = true;
            this.ClientRemoveBtn.Click += new System.EventHandler(this.ClientRemoveBtn_Click);
            // 
            // ClientAddNewBtn
            // 
            this.ClientAddNewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientAddNewBtn.Location = new System.Drawing.Point(687, 174);
            this.ClientAddNewBtn.Name = "ClientAddNewBtn";
            this.ClientAddNewBtn.Size = new System.Drawing.Size(75, 23);
            this.ClientAddNewBtn.TabIndex = 21;
            this.ClientAddNewBtn.Text = "Add new";
            this.ClientAddNewBtn.UseVisualStyleBackColor = true;
            this.ClientAddNewBtn.Click += new System.EventHandler(this.ClientAddNewBtn_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(595, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "INN";
            // 
            // ClientINNTxt
            // 
            this.ClientINNTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientINNTxt.Location = new System.Drawing.Point(595, 109);
            this.ClientINNTxt.Name = "ClientINNTxt";
            this.ClientINNTxt.Size = new System.Drawing.Size(167, 20);
            this.ClientINNTxt.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(595, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "GLN";
            // 
            // ClientGLNTxt
            // 
            this.ClientGLNTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientGLNTxt.Location = new System.Drawing.Point(595, 70);
            this.ClientGLNTxt.Name = "ClientGLNTxt";
            this.ClientGLNTxt.Size = new System.Drawing.Size(167, 20);
            this.ClientGLNTxt.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(595, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Name";
            // 
            // ClientNameTxt
            // 
            this.ClientNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientNameTxt.Location = new System.Drawing.Point(595, 31);
            this.ClientNameTxt.Name = "ClientNameTxt";
            this.ClientNameTxt.Size = new System.Drawing.Size(167, 20);
            this.ClientNameTxt.TabIndex = 15;
            // 
            // ClientsTbl
            // 
            this.ClientsTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientsTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsTbl.Location = new System.Drawing.Point(6, 6);
            this.ClientsTbl.Name = "ClientsTbl";
            this.ClientsTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientsTbl.Size = new System.Drawing.Size(583, 373);
            this.ClientsTbl.TabIndex = 14;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.SuppliersChangeBtn);
            this.tabPage3.Controls.Add(this.SupplierRoamingChk);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.SupplierKPPTxt);
            this.tabPage3.Controls.Add(this.SupplierRemoveBtn);
            this.tabPage3.Controls.Add(this.SupplierAddNewBtn);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.SupplierINNTxt);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.SupplierGLNTxt);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.SupplierNameTxt);
            this.tabPage3.Controls.Add(this.SupplierTbl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Поставщики";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SuppliersChangeBtn
            // 
            this.SuppliersChangeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SuppliersChangeBtn.Location = new System.Drawing.Point(598, 293);
            this.SuppliersChangeBtn.Name = "SuppliersChangeBtn";
            this.SuppliersChangeBtn.Size = new System.Drawing.Size(75, 42);
            this.SuppliersChangeBtn.TabIndex = 37;
            this.SuppliersChangeBtn.Text = "Save changes";
            this.SuppliersChangeBtn.UseVisualStyleBackColor = true;
            this.SuppliersChangeBtn.Click += new System.EventHandler(this.SuppliersChangeBtn_Click);
            // 
            // SupplierRoamingChk
            // 
            this.SupplierRoamingChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierRoamingChk.AutoSize = true;
            this.SupplierRoamingChk.Location = new System.Drawing.Point(595, 174);
            this.SupplierRoamingChk.Name = "SupplierRoamingChk";
            this.SupplierRoamingChk.Size = new System.Drawing.Size(74, 17);
            this.SupplierRoamingChk.TabIndex = 36;
            this.SupplierRoamingChk.Text = "Roaming?";
            this.SupplierRoamingChk.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(595, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "KPP";
            // 
            // SupplierKPPTxt
            // 
            this.SupplierKPPTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierKPPTxt.Location = new System.Drawing.Point(595, 148);
            this.SupplierKPPTxt.Name = "SupplierKPPTxt";
            this.SupplierKPPTxt.Size = new System.Drawing.Size(167, 20);
            this.SupplierKPPTxt.TabIndex = 34;
            // 
            // SupplierRemoveBtn
            // 
            this.SupplierRemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierRemoveBtn.Location = new System.Drawing.Point(598, 341);
            this.SupplierRemoveBtn.Name = "SupplierRemoveBtn";
            this.SupplierRemoveBtn.Size = new System.Drawing.Size(75, 38);
            this.SupplierRemoveBtn.TabIndex = 33;
            this.SupplierRemoveBtn.Text = "Remove selected";
            this.SupplierRemoveBtn.UseVisualStyleBackColor = true;
            this.SupplierRemoveBtn.Click += new System.EventHandler(this.SupplierRemoveBtn_Click);
            // 
            // SupplierAddNewBtn
            // 
            this.SupplierAddNewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierAddNewBtn.Location = new System.Drawing.Point(687, 198);
            this.SupplierAddNewBtn.Name = "SupplierAddNewBtn";
            this.SupplierAddNewBtn.Size = new System.Drawing.Size(75, 23);
            this.SupplierAddNewBtn.TabIndex = 32;
            this.SupplierAddNewBtn.Text = "Add new";
            this.SupplierAddNewBtn.UseVisualStyleBackColor = true;
            this.SupplierAddNewBtn.Click += new System.EventHandler(this.SupplierAddNewBtn_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(595, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "INN";
            // 
            // SupplierINNTxt
            // 
            this.SupplierINNTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierINNTxt.Location = new System.Drawing.Point(595, 109);
            this.SupplierINNTxt.Name = "SupplierINNTxt";
            this.SupplierINNTxt.Size = new System.Drawing.Size(167, 20);
            this.SupplierINNTxt.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(595, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "GLN";
            // 
            // SupplierGLNTxt
            // 
            this.SupplierGLNTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierGLNTxt.Location = new System.Drawing.Point(595, 70);
            this.SupplierGLNTxt.Name = "SupplierGLNTxt";
            this.SupplierGLNTxt.Size = new System.Drawing.Size(167, 20);
            this.SupplierGLNTxt.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(595, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Name";
            // 
            // SupplierNameTxt
            // 
            this.SupplierNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierNameTxt.Location = new System.Drawing.Point(595, 31);
            this.SupplierNameTxt.Name = "SupplierNameTxt";
            this.SupplierNameTxt.Size = new System.Drawing.Size(167, 20);
            this.SupplierNameTxt.TabIndex = 26;
            // 
            // SupplierTbl
            // 
            this.SupplierTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierTbl.Location = new System.Drawing.Point(6, 6);
            this.SupplierTbl.Name = "SupplierTbl";
            this.SupplierTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplierTbl.Size = new System.Drawing.Size(583, 373);
            this.SupplierTbl.TabIndex = 25;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.WayBillsTbl);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(768, 385);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Накладные";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // WayBillsTbl
            // 
            this.WayBillsTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WayBillsTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WayBillsTbl.Location = new System.Drawing.Point(3, 9);
            this.WayBillsTbl.Name = "WayBillsTbl";
            this.WayBillsTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WayBillsTbl.Size = new System.Drawing.Size(762, 373);
            this.WayBillsTbl.TabIndex = 26;
            // 
            // NewMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NewMainForm";
            this.Text = "Главная форма";
            this.Load += new System.EventHandler(this.NewMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TradeObjectTbl)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsTbl)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTbl)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WayBillsTbl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView TradeObjectTbl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TONameTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TOGlnTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TOAddressTxt;
        private System.Windows.Forms.Button TORemoveBtn;
        private System.Windows.Forms.Button TOAddNewBtn;
        private System.Windows.Forms.ComboBox TOClientCmb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TOLocalFolderTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TOFtpPasswordTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TOFtpLoginTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ClientKPPTxt;
        private System.Windows.Forms.Button ClientRemoveBtn;
        private System.Windows.Forms.Button ClientAddNewBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ClientINNTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ClientGLNTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ClientNameTxt;
        private System.Windows.Forms.DataGridView ClientsTbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SupplierKPPTxt;
        private System.Windows.Forms.Button SupplierRemoveBtn;
        private System.Windows.Forms.Button SupplierAddNewBtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SupplierINNTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SupplierGLNTxt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox SupplierNameTxt;
        private System.Windows.Forms.DataGridView SupplierTbl;
        private System.Windows.Forms.CheckBox SupplierRoamingChk;
        private System.Windows.Forms.DataGridView WayBillsTbl;
        private System.Windows.Forms.Button TOSaveBtn;
        private System.Windows.Forms.Button ClientsSaveBtn;
        private System.Windows.Forms.Button SuppliersChangeBtn;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exchangeToolStripMenuItem;
    }
}