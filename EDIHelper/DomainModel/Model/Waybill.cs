using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Model
{
    public class Waybill : IEntity
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public Supplier Supplier { get; set; }
        public Client Client { get; set; }

        public void Reinitialization(IEntity other)
        {
            throw new NotImplementedException();
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
