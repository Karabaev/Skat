namespace DomainModel.Logic
{
    using System;
    using System.Xml;
    using System.Collections.Generic;
    using System.Linq;
    using ArxOne.Ftp;
    using System.Net;
    using System.IO;
    using Model;
    using XML;

    public class ManagerFtp
    {
        private readonly FtpPath FtpPath;
        private readonly bool isPassive;
        private readonly Logger logger;
        private readonly WBService wBService;

        public ManagerFtp(string ftpUri, bool isPassive, Logger logger)
        {
            this.FTPUri = new Uri(ftpUri);
            this.FtpPath = new FtpPath(SettingsContainer.GetSettings().FtpFolder);
            this.isPassive = isPassive;
            this.logger = logger;
            this.wBService = new WBService(logger);
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
                this.logger.WriteLog("Document files count in directory: " + ftpClient.ListEntries(FtpPath).Count().ToString());
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

                            try
                            {
                                this.logger.WriteLog("Parsing waybill.");
                                XMLConverter converter = new XMLConverter(byteList, this.logger);
                                if(!this.wBService.AddRecord(converter.GetWaybill()))
                                {
                                    this.logger.WriteLog(string.Format("{0}: {1}", "Waybill or register writing error. File", item.Name), LogTypes.ERROR);
                                }
                            }
                            catch(XmlException ex)
                            {
                                this.logger.WriteLog(string.Format("{0}. File: {1}. {2}: {3}. {4}", "Waybill file parsing error", item.Name, ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                            }
                            catch (Exception ex)
                            {
                                this.logger.WriteLog(string.Format("{0}. File: {1}. {2}: {3}. {4}", "Error adding waybill to db", item.Name, ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                            }

                            File.WriteAllBytes(tradeObject.LocalFolder + "\\" + item.Name, byteList.ToArray());

                            if (ftpClient.Dele(item.Path))
                            {
                                this.logger.WriteLog("File " + item.Path + " was deleted from FTP", LogTypes.INFO);
                            }
                            else
                            {
                                this.logger.WriteLog("File " + item.Path + " not deleted from FTP", LogTypes.WARNING);
                            }

                            this.logger.WriteLog("Saved waybill file " + item.Name, LogTypes.INFO);
                        }
                    }
                    catch (IOException ex)
                    {
                        this.logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error to save waybill file " + item.Name, ex.Source, ex.Message, ex.StackTrace), LogTypes.ERROR);
                    }
                }
            }
        }

        public Uri FTPUri { get; private set; }
    }
}
