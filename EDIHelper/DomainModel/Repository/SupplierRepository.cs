using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repository
{
    using Model;

    public class SupplierRepository : IRepository<Supplier>
    {
        public SupplierRepository()
        {
            this.Context = new Context();
        }

        public bool AddEntity(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Supplier GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Context Context { get; set; }
    }
}
