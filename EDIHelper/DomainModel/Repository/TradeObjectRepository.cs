using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repository
{
    using Model;

    public class TradeObjectRepository : IRepository<TradeObject>
    {
        public TradeObjectRepository()
        {
            this.Context = new Context();
        }

        public bool AddEntity(TradeObject entity)
        {
            this.Context.TradeObjects.Add(entity);
            return this.Context.SaveChanges() > 0;
        }

        public List<TradeObject> GetAllEntities()
        {
            return this.Context.TradeObjects.ToList();
        }

        public TradeObject GetEntity(int id)
        {
            return this.Context.TradeObjects.Where(to => to.ID == id).FirstOrDefault();
        }

        public bool RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(TradeObject entity)
        {
            throw new NotImplementedException();
        }

        public Context Context { get; set; }
    }
}
