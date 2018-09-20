namespace DomainModel.Logic.XML
{
    /// <summary>
    /// Товар из XML документа.
    /// </summary>
    public class WarePosition
    {
        public WarePosition(string xmlContent)
        {}

        /// <summary>
        /// Порядковый номер позиции.
        /// </summary>
        public int PositionNumber { get; set; }
        /// <summary>
        /// ШК
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// Название товара.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Сумма с НДС.
        /// </summary>
        public decimal AmountWithWat { get; set; }
        /// <summary>
        /// Налоговая ставка.
        /// </summary>
        public float TaxRate { get; set; }

    }
}
