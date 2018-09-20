namespace DomainModel.Logic.XML
{
    using System;
    using System.Collections.Generic;

    public class WayBillDocument
    {
        public WayBillDocument(string xmlContent) { }
        /// <summary>
        /// Номер документа.
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Дата документа.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// ГЛН покупателя.
        /// </summary>
        public string Buyer { get; set; }
        /// <summary>
        /// ГЛН поставщика.
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// ГЛН торгового объекта.
        /// </summary>
        public string DeliveryPlace { get; set; }
        /// <summary>
        /// Лист товаров.
        /// </summary>
        public List<WarePosition> Wares { get; set; }
    }
}
