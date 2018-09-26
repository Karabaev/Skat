namespace DomainModel.Model
{
    public class Client : ICounteragent
    {
        public int ID { get; set; }
        public string ExCode { get; set; }
        public string Name { get; set; }
        public string GLN { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }

        public void Reinitialization(IEntity other)
        {
            if (!(other is Client newClient))
            {
                return;
            }

            this.Name = newClient.Name;
            this.ExCode = newClient.ExCode;
            this.GLN = newClient.GLN;
            this.INN = newClient.INN;
            this.KPP = newClient.KPP;
        }

        public override bool Equals(object other)
        {
            Client client = other as Client;
            return client != null && this.ID == client.ID && this.Name == client.Name && this.GLN == client.GLN && this.INN == client.INN && this.KPP == client.KPP;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.ID, this.Name);
           // return string.Format("{0}, Name: {1}, GLN: {2}, INN: {3}, KPP: {4}", this.ID, this.Name, this.GLN, this.INN, this.KPP);
        }

        public bool LikeAs(IEntity other)
        {
            throw new System.NotImplementedException();
        }
    }
}
