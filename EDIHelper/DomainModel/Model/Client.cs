namespace DomainModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Repository;

    public class Client : ICounteragent
    {
        public int ID { get; set; }
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
            this.GLN = newClient.GLN;
            this.INN = newClient.INN;
            this.KPP = newClient.KPP;
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
            return string.Format("Client ID: {0}, Name: {1}, GLN: {2}, INN: {3}, KPP: {4}", this.ID, this.Name, this.GLN, this.INN, this.KPP);
        }
    }
}
