namespace FTPTransporter
{
    using System;
    using System.ServiceProcess;
    using System.Text;
    using System.Timers;
    using DomainModel.Logic;
    using DomainModel.Model;
    using DomainModel.Repository;
    using System.IO;
    using System.Diagnostics;
    using System.Reflection;

    /// <summary>
    /// Класс службы транспорта.
    /// </summary>
    public partial class FTPTransporter : ServiceBase
    {
        private readonly ManagerFtp FtpManager;
        private readonly Logger Logger;
        private readonly Timer Timer;
        private readonly Settings Settings;
        private readonly WayBillRepository WayBillRepository;
        private readonly TradeObjectRepository TradeObjectRepository;

        public FTPTransporter()
        {
            InitializeComponent();
            
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                this.Settings = SettingsContainer.GetSettings();
            }
            catch(Exception ex)
            {
                EventLog.Source = "FtpTransporter";
                EventLog.WriteEntry(string.Format("{0}: {1}. {2}", ex.StackTrace, ex.Message, "Error to initialization settings from database."));
            }

            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
            this.ServiceName = this.Settings.ServiceName;
            EventLog.Source = this.ServiceName;
            this.Logger = new Logger(string.Format("{0}.{1}", this.ServiceName, "log"), this.ServiceName);
            this.Timer = new Timer();
            this.FtpManager = new ManagerFtp(this.Settings.FtpUri, Convert.ToBoolean(this.Settings.FtpIsPassive), 
                                            this.Settings.FtpTimeoutSec, this.Logger);
            this.WayBillRepository = new WayBillRepository();
            this.TradeObjectRepository = new TradeObjectRepository();
        }

        /// <summary>
        /// Событие запуска службы.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            StringBuilder log = new StringBuilder();
            log.AppendFormat("Service started. Ftp URI: {0}  Check interval: {1} seconds. Passive ftp: {2}. Timeout: {3} seconds",
                this.Settings.FtpUri, this.Settings.FtpDownloadInttervalSec, this.Settings.FtpIsPassive, this.Settings.FtpTimeoutSec);
            this.Timer.Enabled = true;
            this.Timer.Interval = this.Settings.FtpDownloadInttervalSec * 1000;
            this.Timer.Elapsed += new ElapsedEventHandler(Tick);
            this.Timer.AutoReset = true;
            this.Timer.Start();
            this.Logger.WriteLog(log.ToString());
        }

        /// <summary>
        /// Событие остановки службы.
        /// </summary>
        protected override void OnStop()
        {
            this.Logger.WriteLog("Service stopped.");

        }

        /// <summary>
        /// Событие тика таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, ElapsedEventArgs e)
        {
            this.Logger.WriteLog("Start checking waybills on a FTP server");


            foreach (var item in this.TradeObjectRepository.GetAllEntities())
            {
                this.Logger.WriteLog("Checking object ID:" + item.ID + " " + item.Name);

                try
                {
                    this.FtpManager.DownloadFiles(item);
                }
                catch (Exception ex)
                {
                    this.Logger.WriteLog(string.Format("{0}, {1}: {2}. Error to downloading waybills", ex.Source, ex.StackTrace, ex.Message), LogTypes.ERROR);
                }
            }


            this.Logger.WriteLog("End checking waybills on a FTP server");
        }
    }
}
