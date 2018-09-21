namespace DomainModel.Logic.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using Model;
    using Repository;

    public class XMLConverter
    {
        public XMLConverter(List<byte> bytes, Logger logger)
        {
            this.Logger = logger;
            this.SupplierRepository = new SupplierRepository();
            this.ClientRepository = new ClientRepository();
            this.FileContent = Encoding.GetEncoding("windows-1251").GetString(bytes.ToArray());
            this.XmlDocument = new XmlDocument();
            this.XmlDocument.LoadXml(this.FileContent);
            this.XmlRoot = this.XmlDocument.DocumentElement;
        }

        public Waybill GetWaybill()
        {
            int supplierID = -1, clientID = -1;
            DateTime docDate = new DateTime(1970, 1, 1);
            string number = string.Empty;
            try
            {
                number = this.XmlRoot.SelectSingleNode(EDIDocumentStruct.DocumentNodeNames[DocumentNodes.NUMBER]).InnerText;
                string docDateStr = this.XmlRoot.SelectSingleNode(EDIDocumentStruct.DocumentNodeNames[DocumentNodes.DATE]).InnerText;
                XmlNode xmlHeader = this.XmlRoot.SelectSingleNode(EDIDocumentStruct.DocumentNodeNames[DocumentNodes.HEAD]);
                string supplierGln = xmlHeader.SelectSingleNode(EDIDocumentStruct.DocumentNodeNames[DocumentNodes.SUPPLIER]).InnerText;
                string clientGln = xmlHeader.SelectSingleNode(EDIDocumentStruct.DocumentNodeNames[DocumentNodes.BUYER]).InnerText;

                try
                {
                    docDate = DateTime.Parse(docDateStr);
                }
                catch (FormatException ex)
                {
                    this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error reading document date", ex.Source, ex.Message, ex.StackTrace), LogTypes.WARNING);
                    docDate = new DateTime(2000, 1, 1);
                }

                try
                {
                    supplierID = this.SupplierRepository.GetAllEntities().
                            Where(s => this.Trim(s.GLN) == this.Trim(supplierGln)).FirstOrDefault().ID;
                    
                }
                catch (NullReferenceException ex)
                {
                    this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Supplier with GLN " + supplierGln + " not found", ex.Source, ex.Message, ex.StackTrace), LogTypes.WARNING);
                }

                try
                {
                    clientID = this.ClientRepository.GetAllEntities().
                                    Where(c => this.Trim(c.GLN) == this.Trim(clientGln)).FirstOrDefault().ID;
                }
                catch (NullReferenceException ex)
                {
                    this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Client with GLN " + clientGln + " not found", ex.Source, ex.Message, ex.StackTrace));
                }
            }
            catch (XPathException ex)
            {
                this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error reading document", ex.Source, ex.Message, ex.StackTrace));
            }

            Waybill result = new Waybill
            {
                ClientID = clientID,
                DocumentDate = docDate,
                DownloadDate = DateTime.Now,
                Number = number,
                SupplierID = supplierID
            };

            return result;
        }

        private string Trim(string str)
        {
            return str.Trim(' ');
        }

        private Logger Logger { get; set; }
        private string FileContent { get; set; }
        private XmlDocument XmlDocument { get; set; }
        private XmlElement XmlRoot { get; set; }
        private SupplierRepository SupplierRepository { get; set; }
        private ClientRepository ClientRepository { get; set; }
    }
}
