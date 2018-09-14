using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FTPTransporter
{
    using FTPGui.BusinessLogicLayer;
    using FTPGui.DataAccessLayer;

    public partial class FTPTransporter : ServiceBase
    {
        private FTPManager ftpManager;
        private Repository repository;
        private Logger logger;
        private System.Timers.Timer timer;

        public FTPTransporter()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;

            this.ServiceName = SettingsContainer.Settings.ServiceName;
            this.logger = new Logger(SettingsContainer.Settings.ServiceLogFileFullPath);
            this.timer = new System.Timers.Timer();
            this.ftpManager = new FTPManager(SettingsContainer.Settings.FtpUri, SettingsContainer.Settings.IsPassiveFtp, logger);
            this.repository = new Repository(logger);
        }

        protected override void OnStart(string[] args)
        {
            StringBuilder log = new StringBuilder();
            log.AppendFormat("Service started. Ftp URI: {0}  Check interval: {1} seconds. Passive ftp: {2}", 
                SettingsContainer.Settings.FtpUri, SettingsContainer.Settings.TransporterListenIntervalSec, SettingsContainer.Settings.IsPassiveFtp);
            logger.WriteLog(log.ToString());


            
            this.timer.Enabled = true;
            this.timer.Interval = SettingsContainer.Settings.TransporterListenIntervalSec * 1000;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(Tick);
            this.timer.AutoReset = true;
            this.timer.Start();
        }

        protected override void OnStop()
        {
            logger.WriteLog("Service stopped.");

        }

        private void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            logger.WriteLog("Start checking waybills on a FTP server");

            try
            {
                foreach (var item in repository.AccessDataList)
                {
                    logger.WriteLog("Checking object ID:" + item.ID + " " + item.ShopName);
                    this.ftpManager.DownloadFiles(item);
                }
            }
            catch (NullReferenceException ex)
            {
                logger.WriteLog("Error to downloading waybills.");
                logger.WriteLog(ex.StackTrace + ":" + ex.Message);
            }

            logger.WriteLog("End checking waybills on a FTP server");
        }
    }
}
