namespace DomainModel.Model
{
    using System;
    using System.ComponentModel;

    public class Waybill : IEntity
    {
        public int ID { get; set; }
        public string Number { get; set; }
        [Browsable(false)]
        public int SupplierID { get; set; }
        [Browsable(false)]
        public int ClientID { get; set; }
        public Supplier Supplier { get; set; }
        public Client Client { get; set; }

        public void Reinitialization(IEntity other)
        {
            if (!(other is Waybill newWayBill))
            {
                return;
            }

            this.Number = newWayBill.Number;
            this.SupplierID = newWayBill.SupplierID;
            this.ClientID = newWayBill.ClientID;
            this.Supplier = newWayBill.Supplier;
            this.Client = newWayBill.Client;
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
            return base.ToString();
        }
    }
}
