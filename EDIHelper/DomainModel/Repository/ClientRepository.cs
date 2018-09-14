namespace DomainModel.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
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
            throw new NotImplementedException();
        }

        public List<Client> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public Client GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Client entity)
        {
            throw new NotImplementedException();
        }

        public Context Context { get; set; }
    }
}
