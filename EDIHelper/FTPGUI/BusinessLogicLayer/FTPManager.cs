namespace FTPGui.BusinessLogicLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArxOne.Ftp;
    using System.Net;
    using System.IO;

    /// <summary>
    /// Класс для работы с ФТП сервером.
    /// </summary>
    public class FTPManager
    {
        private readonly FtpPath FtpPath;
        private readonly Logger logger;
        private readonly bool isPassive;

        /// <summary>
        /// Инициализирует объект в памяти.
        /// </summary>
        /// <param name="ftpUri">URI ФТП сервера.</param>
        /// <param name="isPassive">Пассивный режим.</param>
        /// <param name="logger">Ссылка на логгер.</param>
        public FTPManager(string ftpUri, bool isPassive, Logger logger)
        {
            this.FTPUri = new Uri(ftpUri);
            this.logger = logger;
            this.FtpPath = new FtpPath(SettingsContainer.Settings.WayBillsFtpPath);
            this.isPassive = isPassive;
        }

        /// <summary>
        /// Загружает файлы с ФТП сервера, находящиеся по пути, указанному в настройках, после чего удаляет их.
        /// </summary>
        /// <param name="access">Ссылка на объект, в котором хранятся параметры доступа к ФТП.</param>
        public void DownloadFiles(FTPAccessData access)
        {
            NetworkCredential networkCredential = new NetworkCredential(access.Login, access.Password);
            FtpClientParameters parametres = new FtpClientParameters();
            parametres.ConnectTimeout = new TimeSpan(0, 0, 5);
            parametres.ReadWriteTimeout = new TimeSpan(0, 0, 5);
            parametres.Passive = this.isPassive;
            using (var ftpClient = new FtpClient(this.FTPUri, networkCredential, parametres))
            {
                var files = ftpClient.ListEntries(FtpPath).Where(en => en.Type == FtpEntryType.File);
                foreach (var item in files)
                {
                    using (var stream = ftpClient.Retr(item.Path))
                    {
                        List<byte> byteList = new List<byte>();
                        int curByte;

                        while ((curByte = stream.ReadByte()) != -1)
                        {
                            byteList.Add((byte)curByte);
                        }

                        try
                        {
                            File.WriteAllBytes(access.LocalFolder + "\\" + item.Name, byteList.ToArray());

                            if(ftpClient.Dele(item.Path))
                            {
                                this.logger.WriteLog("File " + item.Path + " was deleted from FTP");
                            }
                            else
                            {
                                this.logger.WriteLog("File " + item.Path + " not deleted from FTP", LogTypes.ERROR);
                            }

                            this.logger.WriteLog("Saved waybill file " + item.Name);
                        }
                        catch(IOException ex)
                        {
                            this.logger.WriteLog("Error to save waybill file " + item.Name, LogTypes.ERROR);
                            this.logger.WriteLog(ex.StackTrace + " " + ex.Message, LogTypes.ERROR);
                        }
                        
                    }
                }
            }
        }

        /// <summary>
        /// URI ФТП сервера.
        /// </summary>
        public Uri FTPUri { get; private set; }
    }
}
