namespace DomainModel.Logic.XML
{
    using System.Collections.Generic;

    /// <summary>
    /// Типы документов.
    /// </summary>
    public enum DocumentTypes
    {
        WayBill
    }

    /// <summary>
    /// Узлы XML файлов документов.
    /// </summary>
    public enum DocumentNodes
    {
        NUMBER,
        DATE,
        HEAD,
        BUYER,
        SUPPLIER,
        DELIVERYPLACE
    }

    public static class EDIDocumentStruct
    {
        public static Dictionary<DocumentTypes, string> DocumentNames { get; private set; }
        public static Dictionary<DocumentNodes, string> DocumentNodeNames { get; private set; }


        static EDIDocumentStruct()
        {
            DocumentNames = new Dictionary<DocumentTypes, string>();
            DocumentNames.Add(DocumentTypes.WayBill, "DESADV");

            DocumentNodeNames = new Dictionary<DocumentNodes, string>();
            DocumentNodeNames.Add(DocumentNodes.NUMBER, DocumentNodes.NUMBER.ToString());
            DocumentNodeNames.Add(DocumentNodes.DATE, DocumentNodes.DATE.ToString());
            DocumentNodeNames.Add(DocumentNodes.HEAD, DocumentNodes.HEAD.ToString());
            DocumentNodeNames.Add(DocumentNodes.BUYER, DocumentNodes.BUYER.ToString());
            DocumentNodeNames.Add(DocumentNodes.SUPPLIER, DocumentNodes.SUPPLIER.ToString());
            DocumentNodeNames.Add(DocumentNodes.DELIVERYPLACE, DocumentNodes.DELIVERYPLACE.ToString());
        }
    }
}
