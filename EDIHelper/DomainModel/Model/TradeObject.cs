﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Model
{
    public class TradeObject : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string GLN { get; set; }

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
            return string.Format("ID: {0}, Name: {1}, Address: {2}, GLN: {3}", this.ID, this.Name, this.Address, this.GLN);
        }
    }
}
