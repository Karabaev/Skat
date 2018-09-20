namespace DomainModel.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class AccumRegisterRepository : IRepository<AccumulationRegister>
    {
        public AccumRegisterRepository()
        {
            this.Context = new Context();
        }

        public bool AddEntity(int clientID, int waybillID, DateTime dateTime, int value, bool? isRoaming)
        {
            AccumulationRegister newRecord = new AccumulationRegister
            {
                ClientID = clientID,
                DateTime = dateTime,
                IsRoaming = isRoaming,
                WaybillID = waybillID,
                Value = value,
                Amount = this.GetAmount() + value
            };

            this.Context.AccumulationRegister.Add(newRecord);
            return this.SaveChanges();
        }

        public bool AddEntity(AccumulationRegister entity)
        {
            throw new NotImplementedException();
        }

        public List<AccumulationRegister> GetAllEntities()
        {
            return this.Context.AccumulationRegister.ToList();
        }

        public AccumulationRegister GetEntity(int id)
        {
            return this.Context.AccumulationRegister.Where(c => c.ID == id).FirstOrDefault();
        }

        public bool RemoveEntity(int id)
        {
            this.Context.AccumulationRegister.Remove(this.Context.AccumulationRegister.Where(c => c.ID == id).FirstOrDefault());
            return this.SaveChanges();
        }

        public bool SaveChanges()
        {
            return this.Context.SaveChanges() > 0;
        }

        public bool UpdateEntity(AccumulationRegister entity)
        {
            if (entity == null)
            {
                return false;
            }

            AccumulationRegister old = this.GetEntity(entity.ID);

            if (old == null)
            {
                return false;
            }

            old.Reinitialization(entity);

            return this.SaveChanges();
        }

        private int GetAmount()
        {
            return this.GetAllEntities().Sum(ar => ar.Value);
        }

        public Context Context { get; set; }
    }
}
