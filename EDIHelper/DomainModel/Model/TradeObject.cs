namespace DomainModel.Model
{
    using System;
    using System.ComponentModel;

    public class TradeObject : IEntity
    {
        public int ID { get; set; }
        public string ExCode { get; set; }
        public string Name { get; set; }
        public string FtpLogin { get; set; }
        public string FtpPassword { get; set; }
        public string LocalFolder { get; set; }
        public string Address { get; set; }
        public string GLN { get; set; }
        [DisplayName("Client ID")]
        public int ClientID { get; set; }

        public void Reinitialization(IEntity other)
        {
            if (!(other is TradeObject newTO))
            {
                return;
            }

            this.Name = newTO.Name;
            this.ExCode = newTO.ExCode;
            this.FtpLogin = newTO.Name;
            this.FtpPassword = newTO.FtpPassword;
            this.LocalFolder = newTO.LocalFolder;
            this.Address = newTO.Address;
            this.GLN = newTO.GLN;
            this.ClientID = newTO.ClientID;
        }

        public override bool Equals(object other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Address: {2}, GLN: {3}", this.ID, this.Name, this.Address, this.GLN);
        }

        public bool LikeAs(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
