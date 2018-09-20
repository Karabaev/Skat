namespace DomainModel.Model
{
    public class Settings : IEntity
    {
        public int ID { get; set; }
        public string FtpUri { get; set; }
        public string FtpFolder { get; set; }
        public int FtpDownloadInttervalSec { get; set; }
        public int FtpIsPassive { get; set; }
        public string ServiceName { get; set; }

        public bool LikeAs(IEntity other)
        {
            throw new System.NotImplementedException();
        }

        public void Reinitialization(IEntity other)
        {
            if (!(other is Settings newSettings))
            {
                return;
            }

            this.FtpUri = newSettings.FtpUri;
            this.FtpFolder = newSettings.FtpFolder;
            this.FtpDownloadInttervalSec = newSettings.FtpDownloadInttervalSec;
            this.FtpIsPassive = newSettings.FtpIsPassive;
            this.ServiceName = newSettings.ServiceName;
        }
    }
}
