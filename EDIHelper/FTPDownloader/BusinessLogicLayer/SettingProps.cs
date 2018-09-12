namespace FTPDownloader.BusinessLogicLayer
{
    using System.IO;

    /// <summary>
    /// Хранилище настроек.
    /// </summary>
    public class SettingProps
    {
        /// <summary>
        /// Инициализирует экземпляр класса SettingProps. 
        /// </summary>
        public SettingProps()
        {
            this.DataFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            this.LogFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            this.ServiceLogFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            this.WayBillsFtpPath = defaultWayBillsFtpPath;
        }

        public SettingProps(SettingProps props)
        {
            this.DataFilePath = props.DataFilePath;
            this.LogFilePath = props.LogFilePath;
            this.ServiceLogFilePath = props.ServiceLogFilePath;
            this.WayBillsFtpPath = props.WayBillsFtpPath;
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

        public string DataFileFullName
        {
            get
            {
                return string.Format("{0}\\{1}", this.DataFilePath == dataFileName ? "" : this.DataFilePath, dataFileName);
            }
        }

        public string LogFileFullPath
        {
            get
            {
                return string.Format("{0}\\{1}", this.LogFilePath == logFilename ? "" : this.LogFilePath, logFilename);
            }
        }

        public string ServiceLogFileFullPath
        {
            get
            {
                return string.Format("{0}\\{1}", this.ServiceLogFilePath, serviceLogFileName);
            }
        }

        private const string dataFileName = "Data.json";
        private const string logFilename = "Log.log";
        private const string serviceLogFileName = "FtpTransporter.Log";
        private const string defaultWayBillsFtpPath = "INBOX";

    }
}
