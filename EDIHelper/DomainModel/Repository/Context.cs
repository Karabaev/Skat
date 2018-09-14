using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repository
{
    using System.Data.Entity;
    using Model;

    public class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TradeObject> TradeObjects { get; set; }
        public DbSet<Waybill> Waybills { get; set; }
    }
}
