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



        /// <summary>
        /// Парсит полученный текст XML и возвращает объект накладной.
        /// </summary>
        /// <returns>Объект накладной, загруженный из XML.</returns>
        public Waybill GetWaybill()
        {
            int supplierID = -1, clientID = -1;
            DateTime docDate = new DateTime(1970, 1, 1);
            string number = string.Empty;
            try
            {
                number = XmlParser.GetTagValue(this.XmlRoot, XmlTags.NUMBER);
                string docDateStr = XmlParser.GetTagValue(this.XmlRoot, XmlTags.DATE);
                XmlNode xmlHeader = XmlParser.GetXmlNode(this.XmlRoot, XmlTags.HEAD);
                string supplierGln = XmlParser.GetTagValue((XmlElement)xmlHeader, XmlTags.SUPPLIER);
                string clientGln = XmlParser.GetTagValue((XmlElement)xmlHeader, XmlTags.BUYER);

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

        public List<Client> GetClients()
        {
            List<Client> result = new List<Client>();
            var clientsNode = XmlParser.GetXmlNode(this.XmlRoot, XmlTags.Clients);
            var clientNodes = XmlParser.GetXmlNodes(clientsNode, XmlTags.Client);

            foreach (XmlNode clientNode in clientNodes)
            {
                string name = XmlParser.GetTagValue((XmlElement)clientNode, XmlTags.Name);
                string gln = XmlParser.GetTagValue((XmlElement)clientNode, XmlTags.GLN);

                if (name == string.Empty || gln == string.Empty)
                {
                    this.Logger.WriteLog("Error parsing client: field Name or GLN incorrect", LogTypes.WARNING);
                    continue;
                }

                Client client = new Client
                {
                    Name = name,
                    GLN = gln,
                    INN = XmlParser.GetTagValue((XmlElement)clientNode, XmlTags.INN),
                    KPP = XmlParser.GetTagValue((XmlElement)clientNode, XmlTags.KPP),
                    ExCode = XmlParser.GetTagValue((XmlElement)clientNode, XmlTags.Code)
                };

                result.Add(client);
            }

            return result;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> result = new List<Supplier>();
            var suppliersNode = XmlParser.GetXmlNode(this.XmlRoot, XmlTags.Suppliers);
            var supplierNodes = XmlParser.GetXmlNodes(suppliersNode, XmlTags.Supplier);

            foreach (XmlNode supplierNode in supplierNodes)
            {
                Supplier supplier = null;
                string name = XmlParser.GetTagValue((XmlElement)supplierNode, XmlTags.Name);
                string gln = XmlParser.GetTagValue((XmlElement)supplierNode, XmlTags.GLN);

                if (name == string.Empty || gln == string.Empty)
                {
                    this.Logger.WriteLog("Error parsing supplier: field Name or GLN incorrect", LogTypes.WARNING);
                    continue;
                }

                try
                {
                    supplier = new Supplier
                    {
                        Name = name,
                        GLN = gln,
                        INN = XmlParser.GetTagValue((XmlElement)supplierNode, XmlTags.INN),
                        KPP = XmlParser.GetTagValue((XmlElement)supplierNode, XmlTags.KPP),
                        IsRoaming = bool.Parse(XmlParser.GetTagValue((XmlElement)supplierNode, XmlTags.Roaming)),
                        ExCode = XmlParser.GetTagValue((XmlElement)supplierNode, XmlTags.Code)
                    };
                }
                catch(FormatException ex)
                {
                    this.Logger.WriteLog(string.Format("{0}: {1}: {2}. {3}", "Error parsing supplier Roaming value. Supplier " + name + " not loaded", ex.Source, ex.Message, ex.StackTrace), LogTypes.WARNING);
                }

                result.Add(supplier);
            }

            return result;
        }

        public List<TradeObject> GetTradeObjects()
        {
            List<TradeObject> result = new List<TradeObject>();
            var tradeObjectsNode = XmlParser.GetXmlNode(this.XmlRoot, XmlTags.TradeObjects);
            var tradeObjectNodes = XmlParser.GetXmlNodes(tradeObjectsNode, XmlTags.TradeObject);

            foreach (XmlNode tradeObjectNode in tradeObjectNodes)
            {
                TradeObject tradeObject = null;
                string name = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.Name);
                string gln = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.GLN);
                string clientCode = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.ClientCode);

                if (name == string.Empty || gln == string.Empty || clientCode == string.Empty)
                {
                    this.Logger.WriteLog("Error parsing trade object: field Name, GLN or ClientCode incorrect", LogTypes.WARNING);
                    continue;
                }

                Client client = null;
                client = ClientRepository.GetAllEntities().Where(c => c.ExCode == clientCode).FirstOrDefault();

                tradeObject = new TradeObject
                {
                    Name = name,
                    GLN = gln,
                    FtpLogin = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.FtpLogin),
                    FtpPassword = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.FtpPassword),
                    LocalFolder = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.LocalFolder),
                    Address = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.Address),
                    ExCode = XmlParser.GetTagValue((XmlElement)tradeObjectNode, XmlTags.Code),
                };

                try
                {
                    tradeObject.ClientID = client.ID;
                }
                catch(NullReferenceException)
                {
                    this.Logger.WriteLog(string.Format("Client with ExCode: {0} not found. Trade object: {2} not loaded.", clientCode, name), LogTypes.WARNING);
                    continue;
                }

                result.Add(tradeObject);
            }

            return result;
        }

        /// <summary>
        /// Удаляет из начала и конца строки пробелы.
        /// </summary>
        /// <param name="str">Входная строка.</param>
        /// <returns>Строка str, без пробелов начале и конце.</returns>
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
