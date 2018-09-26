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
            return this.SaveChanges();
        }

        public List<Client> GetAllEntities()
        {
            return this.Context.Clients.ToList();
        }

        public Client GetEntity(int id)
        {
            return this.Context.Clients.Where(c => c.ID == id).FirstOrDefault();
        }

        public bool RemoveEntity(int id)
        {
            this.Context.Clients.Remove(this.Context.Clients.Where(c => c.ID == id).FirstOrDefault());
            return this.SaveChanges();
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

            return this.SaveChanges();
        }

        public bool AddOrUpdateEntity(Client entity)
        {
            Client client = this.Context.Clients.Where(c => c.ExCode == entity.ExCode).FirstOrDefault();

            if(client != null)
            {
                client.Reinitialization(entity);
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
