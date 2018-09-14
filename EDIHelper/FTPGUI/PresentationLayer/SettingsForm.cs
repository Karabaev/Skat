using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FTPGui.PresentationLayer
{
    using BusinessLogicLayer;

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            DataFileTxt.Text = SettingsContainer.Settings.DataFilePath;
            LogFileTxt.Text = SettingsContainer.Settings.LogFilePath;
            ServiceLogFileTxt.Text = SettingsContainer.Settings.ServiceLogFilePath;
            WBFolderTxt.Text = SettingsContainer.Settings.WayBillsFtpPath;
            FtpUriTxt.Text = SettingsContainer.Settings.FtpUri;
            IntervalTxt.Text = SettingsContainer.Settings.TransporterListenIntervalSec.ToString();
            PassiveChk.Checked = SettingsContainer.Settings.IsPassiveFtp;
        }

        /// <summary>
        /// Нажатие на кнопку изменить файл данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeDataFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SettingsContainer.Settings.DataFilePath = Path.GetFullPath(openFileDialog1.FileName);
                DataFileTxt.Text = SettingsContainer.Settings.DataFilePath;
            }
        }

        /// <summary>
        /// Нажатие на кнопку изменить файл логов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeLogFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SettingsContainer.Settings.LogFilePath = Path.GetFullPath(openFileDialog1.FileName);
                LogFileTxt.Text = SettingsContainer.Settings.LogFilePath;
            }
        }

        /// <summary>
        /// Нажатие на кнопку закрыть и сохранить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            SettingsContainer.Settings.DataFilePath = DataFileTxt.Text;
            SettingsContainer.Settings.LogFilePath = LogFileTxt.Text;
            SettingsContainer.Settings.ServiceLogFilePath = ServiceLogFileTxt.Text;
            SettingsContainer.Settings.WayBillsFtpPath = WBFolderTxt.Text;
            SettingsContainer.Settings.FtpUri = FtpUriTxt.Text;
            SettingsContainer.Settings.TransporterListenIntervalSec = int.Parse(IntervalTxt.Text);
            SettingsContainer.Settings.IsPassiveFtp = PassiveChk.Checked;
            SettingsContainer.Save();
            this.Close();
        }

        private void CloseWithoutSaveBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
