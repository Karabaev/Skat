namespace DomainModel.Model
{
    using System;

    public class AccumulationRegister : IEntity
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        public int ClientID { get; set; }
        /// <summary>
        /// Количество роуминговых накладных у клиента.
        /// </summary>
        public int RoamingAmount { get; set; }
        /// <summary>
        /// Сумма всех накладных у клиента.
        /// </summary>
        public int TotalAmount { get; set; }
        /// <summary>
        /// Дата/время записи.
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Является ли запись роуминговой.
        /// </summary>
        public bool IsRoaming { get; set; }
        /// <summary>
        /// Идентификатор накладной.
        /// </summary>
        public int WaybillID { get; set; }

        public bool LikeAs(IEntity other)
        {
            throw new NotImplementedException();
        }

        public void Reinitialization(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
