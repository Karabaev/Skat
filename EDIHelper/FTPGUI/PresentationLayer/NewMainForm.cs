using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPGui.PresentationLayer
{
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
                Address = TOAddressTxt.Text,
                ClientID = this.GetIDFromString(TOClientCmb.Text),
                FtpLogin = TOFtpLoginTxt.Text,
                FtpPassword = TOFtpPasswordTxt.Text,
                GLN = TOGlnTxt.Text,
                LocalFolder = TOLocalFolderTxt.Text,
                Name = TONameTxt.Text
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
                Name = ClientNameTxt.Text,
                GLN = ClientGLNTxt.Text,
                INN = ClientINNTxt.Text,
                KPP = ClientKPPTxt.Text
            }))
            {
                this.UpdateClientPage();
            }
            else
            {
                //вывести ошибку.
            }
        }

        private void UpdateClientPage()
        {
            this.ClientsTbl.DataSource = this.ClientRepository.GetAllEntities();
        }

        private void ClientRemoveBtn_Click(object sender, EventArgs e)
        {

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
                GLN = SupplierGLNTxt.Text,
                INN = SupplierINNTxt.Text,
                IsRoaming = SupplierRoamingChk.Checked,
                KPP = SupplierKPPTxt.Text,
                Name = SupplierNameTxt.Text
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
    }
}
