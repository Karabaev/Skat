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

    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            this.ClientRepository = new ClientRepository();
            this.WayBillRepository = new WayBillRepository();
            this.AccumRegisterRepository = new AccumRegisterRepository();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.UpdatePage1();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    this.UpdatePage1();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePage1()
        {
            P1ClientTbl.DataSource = this.ClientRepository.GetAllEntities();
        }

        private void UpdateP1WaybillTbl(object source)
        {
            P1WaybillTbl.DataSource = source;
        }

        private void P1ClientTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table = sender as DataGridView;

            if (table == null)
            {
                MessageBox.Show("Critical error.", "Error");
                return;
            }

            List<Waybill> waybills = WayBillRepository.GetAllEntities();
            int clientID = (int)table.Rows[e.RowIndex > 0 ? e.RowIndex : 0].Cells["ID"].Value;

            this.UpdateP1WaybillTbl(waybills.Where(wb => wb.ClientID == clientID).ToList());

            List<AccumulationRegister> accumulations = AccumRegisterRepository.GetAllEntities().Where(a => a.ClientID == clientID).ToList();

            AccumulationRegister lastRecord = accumulations.Where(a => a.DateTime == accumulations.Max(ac => ac.DateTime)).FirstOrDefault();

            if (lastRecord == null)
            {
                P1TotalWbTxt.Text = "waybills not found.";
                P1TotalRoamWbTxt.Text = "waybills not found.";
                return;
            }

            P1TotalWbTxt.Text = lastRecord.TotalAmount.ToString();
            P1TotalRoamWbTxt.Text = lastRecord.RoamingAmount.ToString();
        }

        private ClientRepository ClientRepository { get; set; }
        private WayBillRepository WayBillRepository { get; set; }
        private AccumRegisterRepository AccumRegisterRepository { get; set; }


    }
}
