using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Model
{
    using Repository;

    public class Waybill : IEntity
    {
        public Waybill(int id, string number, int supID, int clientID)
        {
            this.ID = id;
            this.Number = number;
            this.SupplierID = supID;
            this.ClientID = clientID;
        }

        public int ID { get; set; }
        public string Number { get; set; }
        public int SupplierID { get; set; }
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
