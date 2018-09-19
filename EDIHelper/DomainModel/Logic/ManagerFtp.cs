namespace DomainModel.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArxOne.Ftp;
    using System.Net;
    using System.IO;
    using Model;

    public class ManagerFtp
    {
        private readonly FtpPath FtpPath;
        private readonly bool isPassive;
        private readonly Logger logger;

        public ManagerFtp(string ftpUri, bool isPassive, Logger logger)
        {
            this.FTPUri = new Uri(ftpUri);
            this.FtpPath = new FtpPath(SettingsContainer.GetSettings().FtpFolder);
            this.isPassive = isPassive;
            this.logger = logger;
        }

        public void DownloadFiles(TradeObject tradeObject)
        {
            NetworkCredential networkCredential = new NetworkCredential(tradeObject.FtpLogin, tradeObject.FtpPassword);
            FtpClientParameters parametres = new FtpClientParameters();
            parametres.ConnectTimeout = new TimeSpan(0, 0, 20);
            parametres.ReadWriteTimeout = new TimeSpan(0, 0, 20);
            parametres.Passive = this.isPassive;
            using (var ftpClient = new FtpClient(this.FTPUri, networkCredential, parametres))
            {
                var files = ftpClient.ListEntries(FtpPath).Where(en => en.Type == FtpEntryType.File);
                logger.WriteLog("Files count: " + ftpClient.ListEntries(FtpPath).Count().ToString());
                foreach (var item in files)
                {
                    try
                    {
                        using (var stream = ftpClient.Retr(item.Path))
                        {
                            List<byte> byteList = new List<byte>();
                            int curByte;

                            while ((curByte = stream.ReadByte()) != -1)
                            {
                                byteList.Add((byte)curByte);
                            }
                            File.WriteAllBytes(tradeObject.LocalFolder + "\\" + item.Name, byteList.ToArray());

                            if (ftpClient.Dele(item.Path))
                            {
                                logger.WriteLog("File " + item.Path + " was deleted from FTP", LogTypes.INFO);
                            }
                            else
                            {
                                logger.WriteLog("File " + item.Path + " not deleted from FTP", LogTypes.WARNING);
                            }

                            logger.WriteLog("Saved waybill file " + item.Name, LogTypes.INFO);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.WriteLog("Error to save waybill file " + item.Name, LogTypes.ERROR);
                        logger.WriteLog(ex.StackTrace + " " + ex.Message, LogTypes.ERROR);
                    }
                }
            }
        }

        public Uri FTPUri { get; private set; }
    }
}
