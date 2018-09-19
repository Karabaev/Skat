namespace DomainModel.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class TradeObjectRepository : IRepository<TradeObject>
    {
        public TradeObjectRepository()
        {
            this.Context = new Context();
            this.ClientRepository = new ClientRepository();
        }

        /// <summary>
        /// Добавить запись.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(TradeObject entity)
        {
            this.Context.TradeObjects.Add(entity);
            return this.SaveChanges();
        }

        /// <summary>
        /// Получить все записи.
        /// </summary>
        /// <returns></returns>
        public List<TradeObject> GetAllEntities()
        {
            List<TradeObject> result = this.Context.TradeObjects.ToList();

            if (result == null)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Получить запись.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TradeObject GetEntity(int id)
        {
            TradeObject result = this.Context.TradeObjects.Where(to => to.ID == id).FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Удалить запись.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveEntity(int id)
        {
            this.Context.TradeObjects.Remove(this.Context.TradeObjects.Where(to => to.ID == id).FirstOrDefault());
            return this.SaveChanges();
        }

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(TradeObject entity)
        {
            if(entity == null)
            {
                return false;
            }

            TradeObject old = this.GetEntity(entity.ID);

            if(old == null)
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
    }
}
