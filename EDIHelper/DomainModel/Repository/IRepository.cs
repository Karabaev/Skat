using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repository
{
    using Model;

    public interface IRepository<T> where T: IEntity
    {
        Context Context { get; set; }

        T GetEntity(int id);
        List<T> GetAllEntities();
        bool RemoveEntity(int id);
        bool AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool SaveChanges();
    }
}
