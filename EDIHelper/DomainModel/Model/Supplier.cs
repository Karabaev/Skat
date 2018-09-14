using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Model
{
    public class Supplier : ICounteragent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GLN { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public bool IsRoaming { get; set; }

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
