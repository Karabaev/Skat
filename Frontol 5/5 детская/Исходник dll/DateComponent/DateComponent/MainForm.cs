using System;
using System.Windows.Forms;

namespace DateComponent
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DateTimePicker.Date = dateTimePicker1.Value;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DateTimePicker.Date = new DateTime(2000, 1, 1);
            this.Close();
        }
    }
}
