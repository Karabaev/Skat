using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repository
{
    using Model;
    public class WayBillRepository : IRepository<Waybill>
    {
        public WayBillRepository()
        {
            this.Context = new Context();
        }

        public bool AddEntity(Waybill entity)
        {
            this.Context.Waybills.Add(entity);
            return this.Context.SaveChanges() > 1;
        }

        public List<Waybill> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Waybill GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Waybill entity)
        {
            throw new NotImplementedException();
        }

        public Context Context { get; set; }
    }
}
