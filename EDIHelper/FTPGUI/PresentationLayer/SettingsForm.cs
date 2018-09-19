﻿using System;
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
    using DomainModel.Model;
    using DomainModel.Logic;
    //using BusinessLogicLayer;

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
            Settings settings = SettingsContainer.GetSettings();
            WBFolderTxt.Text = settings.FtpFolder;
            FtpUriTxt.Text = settings.FtpUri;
            IntervalTxt.Text = settings.FtpDownloadInttervalSec.ToString();
            PassiveChk.Checked = Convert.ToBoolean(settings.FtpIsPassive);
            ServiceNameTxt.Text = settings.ServiceName;
        }

        /// <summary>
        /// Нажатие на кнопку закрыть и сохранить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            SettingsContainer.SetSettings(new Settings
            {
                FtpUri = FtpUriTxt.Text,
                FtpIsPassive = Convert.ToInt32(PassiveChk.Checked),
                FtpDownloadInttervalSec = int.Parse(IntervalTxt.Text),
                FtpFolder = WBFolderTxt.Text,
                ServiceName = ServiceNameTxt.Text,
            });

            this.Close();
        }

        private void CloseWithoutSaveBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
