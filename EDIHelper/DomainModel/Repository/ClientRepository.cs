namespace DomainModel.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class ClientRepository : IRepository<Client>
    {
        public ClientRepository()
        {
            this.Context = new Context();
        }

        public bool AddEntity(Client entity)
        {
            this.Context.Clients.Add(entity);
            return this.Context.SaveChanges() > 0;
        }

        public List<Client> GetAllEntities()
        {
            List<Client> result = this.Context.Clients.ToList();

            if(result == null)
            {
                return null;
            }

            return result;
        }

        public Client GetEntity(int id)
        {
            Client result = this.Context.Clients.Where(c => c.ID == id).FirstOrDefault();
            return result;
        }

        public bool RemoveEntity(int id)
        {
            this.Context.Clients.Remove(this.Context.Clients.Where(c => c.ID == id).FirstOrDefault());
            return this.Context.SaveChanges() > 0;
        }

        public bool UpdateEntity(Client entity)
        {
            if (entity == null)
            {
                return false;
            }

            Client old = this.GetEntity(entity.ID);

            if (old == null)
            {
                return false;
            }

            old.Reinitialization(entity);

            return this.Context.SaveChanges() > 0;
        }

        public Context Context { get; set; }
    }
}
