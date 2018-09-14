namespace FTPGui.BusinessLogicLayer
{
    /// <summary>
    /// Хранилище настроек.
    /// </summary>
    public class SettingProps
    {
        /// <summary>
        /// Инициализирует экземпляр класса SettingProps стандартными значениями. 
        /// </summary>
        public SettingProps()
        {
            string folderName = "\\FtpTransportHelper";
            this.DataFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + folderName;
            this.LogFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + folderName;
            this.ServiceLogFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + folderName;
            this.WayBillsFtpPath = defaultWayBillsFtpPath;
            this.TransporterListenIntervalSec = DefaultTransporterListenIntervalSec;
            this.FtpUri = DefaultFtpUri;
            this.ServiceName = DefaultTransporterServiceName;
            this.IsPassiveFtp = true;
        }

        
        public SettingProps(SettingProps props)
        {
            this.DataFilePath = props.DataFilePath;
            this.LogFilePath = props.LogFilePath;
            this.ServiceLogFilePath = props.ServiceLogFilePath;
            this.WayBillsFtpPath = props.WayBillsFtpPath;
            this.FtpUri = props.FtpUri;
            this.TransporterListenIntervalSec = props.TransporterListenIntervalSec;
            this.ServiceName = props.ServiceName;
            this.IsPassiveFtp = props.IsPassiveFtp;
        }
        /// <summary>
        /// Полное имя файла, хранящего информацию о магазинах.
        /// </summary>
        public string DataFilePath { get; set; }
        /// <summary>
        /// Полное имя файла, хранящего логи.
        /// </summary>
        public string LogFilePath { get; set; }
        /// <summary>
        /// Полное имя файла, хранящего логи службы.
        /// </summary>
        public string ServiceLogFilePath { get; set; }
        /// <summary>
        /// путь до папки с накладными на сервере.
        /// </summary>
        public string WayBillsFtpPath { get; set; }
        /// <summary>
        /// Интервал опроса ФТП в секундах.
        /// </summary>
        public int TransporterListenIntervalSec { get; set; }
        /// <summary>
        /// Имя службы.
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Пассивный режим ФТП.
        /// </summary>
        public bool IsPassiveFtp { get; set; }
        /// <summary>
        /// Полное имя файла данных.
        /// </summary>
        public string DataFileFullName
        {
            get
            {
                return string.Format("{0}\\{1}", this.DataFilePath == dataFileName ? "" : this.DataFilePath, dataFileName);
            }
        }
        /// <summary>
        /// Полное имя файла логов.
        /// </summary>
        public string LogFileFullPath
        {
            get
            {
                return string.Format("{0}\\{1}", this.LogFilePath == logFilename ? "" : this.LogFilePath, logFilename);
            }
        }
        /// <summary>
        /// Полное имя файла логов службы транспорта.
        /// </summary>
        public string ServiceLogFileFullPath
        {
            get
            {
                return string.Format("{0}\\{1}", this.ServiceLogFilePath, serviceLogFileName);
            }
        }
        /// <summary>
        /// URI ФТП сервера.
        /// </summary>
        public string FtpUri { get; set; }

        private const string dataFileName = "Data.json";
        private const string logFilename = "Log.log";
        private const string serviceLogFileName = "FtpTransporter.Log";
        private const string defaultWayBillsFtpPath = "INBOX";
        private const string DefaultFtpUri = "ftp://localhost";
        private const int DefaultTransporterListenIntervalSec = 600;
        private const string DefaultTransporterServiceName = "FtpTransporter";

    }
}
