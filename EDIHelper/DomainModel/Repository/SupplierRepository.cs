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
            this.Context.Suppliers.Add(entity);
            return this.SaveChanges();
        }

        public List<Supplier> GetAllEntities()
        {
            List<Supplier> result = this.Context.Suppliers.ToList();

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public Supplier GetEntity(int id)
        {
            Supplier result = this.Context.Suppliers.Where(c => c.ID == id).FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public bool RemoveEntity(int id)
        {
            this.Context.Suppliers.Remove(this.Context.Suppliers.Where(c => c.ID == id).FirstOrDefault());
            return this.SaveChanges();
        }

        public bool UpdateEntity(Supplier entity)
        {
            if (entity == null)
            {
                return false;
            }

            Supplier old = this.GetEntity(entity.ID);

            if (old == null)
            {
                return false;
            }

            old.Reinitialization(entity);

            return this.SaveChanges();
        }

        public bool AddOrUpdateEntity(Supplier entity)
        {
            Supplier supplier = this.Context.Suppliers.Where(c => c.ExCode == entity.ExCode).FirstOrDefault();

            if (supplier != null)
            {
                supplier.Reinitialization(entity);
                return SaveChanges();
            }

            return this.AddEntity(entity);
        }

        public bool SaveChanges()
        {
            return this.Context.SaveChanges() > 0;
        }

        public Context Context { get; set; }
    }
}
