namespace FTPGui.PresentationLayer
{
    using System;
    using System.Windows.Forms;
    using DomainModel.Model;
    using DomainModel.Repository;

    public partial class NewMainForm : Form
    {
        public NewMainForm()
        {
            InitializeComponent();
            this.TradeObjectRepository = new TradeObjectRepository();
            this.ClientRepository = new ClientRepository();
            this.SupplierRepository = new SupplierRepository();
            this.WayBillRepository = new WayBillRepository();
        }

        /// <summary>
        /// Открыть настройки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Обновить вкладку торговых объектов.
        /// </summary>
        private void UpdateTradeObjectTbl()
        {
            this.TradeObjectTbl.DataSource = this.TradeObjectRepository.GetAllEntities();
            this.TOClientCmb.Items.Clear();

            foreach (var item in this.ClientRepository.GetAllEntities())
            {
                this.TOClientCmb.Items.Add(item);
            }

            if(this.TOClientCmb.Items.Count > 0)
            {
                this.TOClientCmb.SelectedIndex = 0;
            }
            
        }

        /// <summary>
        /// Загрузка окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMainForm_Load(object sender, EventArgs e)
        {
            this.UpdateTradeObjectTbl();
            this.UpdateClientPage();
        }
        
        /// <summary>
        /// Добавить новый торговый объект/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TOAddNewBtn_Click(object sender, EventArgs e)
        {
            if(this.TradeObjectRepository.AddEntity(new TradeObject
            {
                Address = this.Trim(TOAddressTxt.Text),
                ClientID = this.GetIDFromString(TOClientCmb.Text),
                FtpLogin = this.Trim(TOFtpLoginTxt.Text),
                FtpPassword = this.Trim(TOFtpPasswordTxt.Text),
                GLN = this.Trim(TOGlnTxt.Text),
                LocalFolder = this.Trim(TOLocalFolderTxt.Text),
                Name = this.Trim(TONameTxt.Text)
            }))
            {
                this.UpdateTradeObjectTbl();
            }
            else
            {
                //вывести ошибку
            }
            
        }

        /// <summary>
        /// Удалить торговый объект.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TORemoveBtn_Click(object sender, EventArgs e)
        {
            if(TradeObjectTbl.SelectedRows.Count == 1)
            {
                int id = (int)TradeObjectTbl.SelectedRows[0].Cells["ID"].Value;

                if(!this.TradeObjectRepository.RemoveEntity(id))
                {
                    MessageBox.Show("Error deleting.", "Error");
                }

                this.UpdateTradeObjectTbl();
            }
            else
            {
                MessageBox.Show("You must select 1 row to delete.", "Error");
            }
        }

        /// <summary>
        /// Получить ИД из строки сущности.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetIDFromString(string str)
        {
            int result = -1;
            string[] strs = str.Split(',');
            if(int.TryParse(strs[0], out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        private void ClientAddNewBtn_Click(object sender, EventArgs e)
        {
            if(this.ClientRepository.AddEntity(new Client
            {
                Name = this.Trim(ClientNameTxt.Text),
                GLN = this.Trim(ClientGLNTxt.Text),
                INN = this.Trim(ClientINNTxt.Text),
                KPP = this.Trim(ClientKPPTxt.Text)
            }))
            {
                this.UpdateClientPage();
            }
            else
            {
                //вывести ошибку.
            }
        }

        private string Trim(string str)
        {
            return str.Trim(' ');
        }

        private void UpdateClientPage()
        {
            this.ClientsTbl.DataSource = this.ClientRepository.GetAllEntities();
        }

        private void ClientRemoveBtn_Click(object sender, EventArgs e)
        {
            if (ClientsTbl.SelectedRows.Count == 1)
            {
                int id = (int)ClientsTbl.SelectedRows[0].Cells["ID"].Value;

                if (!this.ClientRepository.RemoveEntity(id))
                {
                    MessageBox.Show("Error deleting.", "Error");
                }

                this.UpdateClientPage();
            }
            else
            {
                MessageBox.Show("You must select 1 row to delete.", "Error");
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    this.UpdateTradeObjectTbl();
                    break;
                case 1:
                    this.UpdateClientPage();
                    break;
                case 2:
                    this.UpdateSupplierPage();
                    break;
                case 3:
                    this.UpdateWaybillPage();
                    break;
                default:
                    break;
            }
        }

        private void SupplierAddNewBtn_Click(object sender, EventArgs e)
        {
            if (this.SupplierRepository.AddEntity(new Supplier
            {
                GLN = this.Trim(SupplierGLNTxt.Text),
                INN = this.Trim(SupplierINNTxt.Text),
                IsRoaming = SupplierRoamingChk.Checked,
                KPP = this.Trim(SupplierKPPTxt.Text),
                Name = this.Trim(SupplierNameTxt.Text)
            }))
            {
                this.UpdateSupplierPage();
            }
            else
            {
                //вывести ошибку
            }
        }

        private void UpdateSupplierPage()
        {
            this.SupplierTbl.DataSource = this.SupplierRepository.GetAllEntities();
        }

        private void UpdateWaybillPage()
        {
            this.WayBillsTbl.DataSource = this.WayBillRepository.GetAllEntities();
        }

        private void TOSaveBtn_Click(object sender, EventArgs e)
        {
            if(!this.TradeObjectRepository.SaveChanges())
            {
                // вывести сообщение
            }
        }

        private void ClientsSaveBtn_Click(object sender, EventArgs e)
        {
            if (!this.ClientRepository.SaveChanges())
            {
                // вывести сообщение
            }
        }

        private void SuppliersChangeBtn_Click(object sender, EventArgs e)
        {
            if (!this.SupplierRepository.SaveChanges())
            {
                // вывести сообщение
            }
        }

        private TradeObjectRepository TradeObjectRepository { get; set; }
        private ClientRepository ClientRepository { get; set; }
        private WayBillRepository WayBillRepository { get; set; }
        private SupplierRepository SupplierRepository { get; set; }

        private void SupplierRemoveBtn_Click(object sender, EventArgs e)
        {
            if (SupplierTbl.SelectedRows.Count == 1)
            {
                int id = (int)SupplierTbl.SelectedRows[0].Cells["ID"].Value;

                if (!this.SupplierRepository.RemoveEntity(id))
                {
                    MessageBox.Show("Error deleting.", "Error");
                }

                this.UpdateClientPage();
            }
            else
            {
                MessageBox.Show("You must select 1 row to delete.", "Error");
            }
            this.UpdateSupplierPage();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm form = new ReportForm();
            form.Show();
        }

        private void exchangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExchangeForm form = new ExchangeForm();
            form.ShowDialog(this);
        }
    }
}
