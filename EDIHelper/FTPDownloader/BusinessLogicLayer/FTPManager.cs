namespace FTPDownloader.BusinessLogicLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArxOne.Ftp;
    using System.Net;
    using System.IO;

    public class FTPManager
    {
        private readonly FtpPath FtpPath;

        public FTPManager(string ftpUri)
        {
            this.FTPUri = new Uri(ftpUri);
            this.FtpPath = new FtpPath(SettingsContainer.Settings.WayBillsFtpPath);
        }

        public void DownloadFiles(FTPAccessData access)
        {
            NetworkCredential networkCredential = new NetworkCredential(access.Login, access.Password);

            using (var ftpClient = new FtpClient(this.FTPUri, networkCredential))
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

                        File.WriteAllBytes(access.LocalFolder + "\\" + item.Name, byteList.ToArray());
                    }
                }
            }
        }

        public IEnumerable<FtpEntry> GetFileList(FTPAccessData access)
        {
            NetworkCredential networkCredential = new NetworkCredential(access.Login, access.Password);

            using (var ftpClient = new FtpClient(this.FTPUri, networkCredential))
            {
                return ftpClient.ListEntries(FtpPath);
            }
        }

        public Uri FTPUri { get; private set; }
    }
}
