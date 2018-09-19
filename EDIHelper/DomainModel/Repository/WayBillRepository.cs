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
            this.ClientRepository = new ClientRepository();
            this.SupplierRepository = new SupplierRepository();
        }

        public bool AddEntity(Waybill entity)
        {
            this.Context.Waybills.Add(entity);
            return this.SaveChanges();
        }

        public List<Waybill> GetAllEntities()
        {
            List<Waybill> result = this.Context.Waybills.ToList();

            if (result == null)
            {
                return null;
            }

            foreach (var item in result)
            {
                item.Client = this.ClientRepository.GetAllEntities().Where(c => c.ID == item.ClientID).FirstOrDefault();
                item.Supplier = this.SupplierRepository.GetAllEntities().Where(s => s.ID == item.SupplierID).FirstOrDefault();
            }

            return result;
        }

        public Waybill GetEntity(int id)
        {
            Waybill result = this.Context.Waybills.Where(wb => wb.ID == id).FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            result.Client = this.ClientRepository.GetAllEntities().Where(c => c.ID == result.ClientID).FirstOrDefault();
            result.Supplier = this.SupplierRepository.GetAllEntities().Where(s => s.ID == result.SupplierID).FirstOrDefault();
            return result;
        }

        public bool RemoveEntity(int id)
        {
            this.Context.Waybills.Remove(this.Context.Waybills.Where(c => c.ID == id).FirstOrDefault());
            return this.SaveChanges();
        }

        public bool UpdateEntity(Waybill entity)
        {
            if (entity == null)
            {
                return false;
            }

            Waybill old = this.GetEntity(entity.ID);

            if (old == null)
            {
                return false;
            }

            old.Reinitialization(entity);

            return this.SaveChanges();
        }

        public bool SaveChanges()
        {
            return this.Context.SaveChanges() > 0;
        }

        public Context Context { get; set; }
        private ClientRepository ClientRepository { get; set; }
        private SupplierRepository SupplierRepository { get; set; }
    }
}
