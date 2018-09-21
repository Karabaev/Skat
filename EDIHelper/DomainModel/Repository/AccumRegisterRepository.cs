namespace DomainModel.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    /// <summary>
    /// Запись регистра нкопления накладных.
    /// </summary>
    public class AccumRegisterRepository : IRepository<AccumulationRegister>
    {
        /// <summary>
        /// Инициализирует объект в памяти.
        /// </summary>
        public AccumRegisterRepository()
        {
            this.Context = new Context();
        }

        /// <summary>
        /// Добавить новую запись в регистр накопления.
        /// </summary>
        /// <param name="clientID">Идентификатор клиента.</param>
        /// <param name="waybillID">Идентификатор накладной.</param>
        /// <param name="dateTime">Дата/время записи.</param>
        /// <param name="isRoaming">Является ли накладная, связанная с этой записью роуминговой.</param>
        /// <returns>true, если операция успешно выполнена, иначе false.</returns>
        public bool AddEntity(int clientID, int waybillID, DateTime dateTime, bool isRoaming)
        {
            AccumulationRegister newRecord = new AccumulationRegister
            {
                ClientID = clientID,
                DateTime = dateTime,
                IsRoaming = isRoaming,
                WaybillID = waybillID,
                RoamingAmount = this.GetClientRoamingAmount(clientID) + (isRoaming ? 1 : 0),
                TotalAmount = this.GetClientTotalAmount(clientID) + 1
            };

            this.Context.AccumulationRegister.Add(newRecord);
            return this.SaveChanges();
        }

        /// <summary>
        /// Не реализовано.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Исключение.</returns>
        public bool AddEntity(AccumulationRegister entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Позвращает все записи регистра накопления.
        /// </summary>
        /// <returns>Контейнер с записями регистра накопления.</returns>
        public List<AccumulationRegister> GetAllEntities()
        {
            return this.Context.AccumulationRegister.ToList();
        }

        /// <summary>
        /// Возвращает запись регистра накопления с указанными id.
        /// </summary>
        /// <param name="id">Идентификатор необходимой записи.</param>
        /// <returns>Запись регистра накопления.</returns>
        public AccumulationRegister GetEntity(int id)
        {
            return this.Context.AccumulationRegister.Where(c => c.ID == id).FirstOrDefault();
        }

        /// <summary>
        /// Удаляет запись регистра накопления с указанными id.
        /// </summary>
        /// <param name="id">Идентификатор необходимой записи.</param>
        /// <returns>true, если операция успешно выполнена, иначе false.</returns>
        public bool RemoveEntity(int id)
        {
            this.Context.AccumulationRegister.Remove(this.Context.AccumulationRegister.Where(c => c.ID == id).FirstOrDefault());
            return this.SaveChanges();
        }

        /// <summary>
        /// Сохранить изменения в базе.
        /// </summary>
        /// <returns>true, если количество изменяемых записей больше нуля, иначе false.</returns>
        public bool SaveChanges()
        {
            return this.Context.SaveChanges() > 0;
        }

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="entity">Новая сущность.</param>
        /// <returns>true, если успешно, иначе false.</returns>
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

        /// <summary>
        /// Возвращает сумму налкадных у указанного клиента.
        /// </summary>
        /// <param name="clientID">Идентификатор клиента.</param>
        /// <returns>Сумма накладных.</returns>
        private int GetClientTotalAmount(int clientID)
        {
            return this.GetAllEntities().Where(ar => ar.ClientID == clientID).Count();
        }

        /// <summary>
        /// Возвращает сумму роуминговых накладных у указанного клиента.
        /// </summary>
        /// <param name="clientID">Идентификатор клиента.</param>
        /// <returns>Сумма роуминговых накладных.</returns>
        private int GetClientRoamingAmount(int clientID)
        {
            return this.GetAllEntities().Where(ar => ar.ClientID == clientID).Where(ar => ar.IsRoaming == true).Count();
        }

        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        public Context Context { get; set; }
    }
}
