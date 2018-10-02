namespace DomainModel.Logic.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Linq;
    using Model;
    using Repository;

    public class XMLConverter
    {
        public XMLConverter(List<byte> bytes, Logger logger)
        {
            this.Logger = logger;
            this.SupplierRepository = new SupplierRepository();
            this.ClientRepository = new ClientRepository();
            this.WayBillRepository = new WayBillRepository();
            this.FileContent = Encoding.GetEncoding("windows-1251").GetString(bytes.ToArray());
            this.XmlDocument = new XmlDocument();
            this.XmlDocument.LoadXml(this.FileContent);
            this.XmlRoot = this.XmlDocument.DocumentElement;
        }

        public XMLConverter(Logger logger)
        {
            this.SupplierRepository = new SupplierRepository();
            this.ClientRepository = new ClientRepository();
            this.WayBillRepository = new WayBillRepository();
            this.AccumRegisterRepository = new AccumRegisterRepository();
            this.Logger = logger;
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
                    this.Logger.WriteLog(string.Format("Client with ExCode: {0} not found. Trade object: {1} not loaded.", clientCode, name), LogTypes.WARNING);
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

        public XDocument GetXmlAll()
        {
            XDocument xDoc = new XDocument();
            XElement document = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.Document]);
            document.Add(this.GetXmlWaybills(this.WayBillRepository.GetAllEntities()), this.GetXmlAccumulation(this.AccumRegisterRepository.GetAllEntities()));
            xDoc.Add(document);
            return xDoc;
        }

        public XDocument GetXmlAllToPeriod(DateTime beginDate, DateTime endDate)
        {
            XDocument xDoc = new XDocument();
            XElement document = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.Document]);
            List<Waybill> waybills = this.WayBillRepository.GetAllEntities().Where(wb => wb.DownloadDate > beginDate && wb.DownloadDate < endDate).ToList();
            List<AccumulationRegister> registerRecords = this.AccumRegisterRepository.GetAllEntities().Where(rr => rr.DateTime > beginDate && rr.DateTime < endDate).ToList();
            document.Add(this.GetXmlWaybills(waybills), this.GetXmlAccumulation(registerRecords));
            xDoc.Add(document);
            return xDoc;
        }

        private XElement GetXmlWaybills(List<Waybill> waybillList)
        {
            XElement waybills = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.WayBills]);

            foreach (var item in waybillList)
            {
                XElement waybill = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.WayBill]);
                XElement code = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.Code], item.ID);
                XElement number = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.Number], item.Number);

                string supCode = string.Empty;

                try
                {
                    supCode = this.SupplierRepository.GetEntity(item.SupplierID).ExCode;
                }
                catch(NullReferenceException)
                {
                    this.Logger.WriteLog(string.Format("Supplier with ID: {0} not found.", item.SupplierID));
                }
                
                XElement supplierCode = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.SupplierCode], supCode);

                string clCode = string.Empty;
                try
                {
                    clCode = this.ClientRepository.GetEntity(item.ClientID).ExCode;
                }
                catch (NullReferenceException)
                {
                    this.Logger.WriteLog(string.Format("Client with ID: {0} not found.", item.ClientID));
                }

                XElement clientCode = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.ClientCode], clCode);
                XElement documentDate = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.DocumentDate], item.DocumentDate.ToString("yyyy-MM-dd"));
                XElement downloadDate = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.DownloadDate], item.DownloadDate.ToString("yyyy-MM-dd hh:mm:ss"));
                waybill.Add(code, number, supplierCode, clientCode, documentDate, downloadDate);
                waybills.Add(waybill);
            }

            return waybills;
        }

        private XElement GetXmlAccumulation(List<AccumulationRegister> accumRegList)
        {
            XElement records = new XElement(XNamespace + XmlParser.XmlTagNames[XmlTags.RegisterRecords]);

            foreach (var item in accumRegList)
            {
                XElement record = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.RegisterRecord]);
                XElement code = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.Code], item.ID);
                XElement wayBillCode = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.WayBillCode], item.WaybillID);

                string clCode = string.Empty;
                try
                {
                    clCode = this.ClientRepository.GetEntity(item.ClientID).ExCode;
                }
                catch (NullReferenceException)
                {
                    this.Logger.WriteLog(string.Format("Client with ID: {0} not found.", item.ClientID));
                }
                XElement clientCode = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.ClientCode], clCode);

                XElement roaming = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.Roaming], item.IsRoaming);
                XElement totalAmount = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.TotalAmount], item.TotalAmount);
                XElement roamingAmount = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.RoamingAmount], item.RoamingAmount);
                XElement dateTime = new XElement(this.XNamespace + XmlParser.XmlTagNames[XmlTags.DateTime], item.DateTime.ToString("yyyy-MM-dd hh:mm:ss"));
                record.Add(code, wayBillCode, clientCode, roaming, totalAmount, roamingAmount, dateTime);
                records.Add(record);
            }
            return records;
        }

 

        private Logger Logger { get; set; }
        private string FileContent { get; set; }
        private XmlDocument XmlDocument { get; set; }
        private XmlElement XmlRoot { get; set; }
        private XNamespace XNamespace { get; set; } = "http://www.1c.ru/EDI/Download";
        private SupplierRepository SupplierRepository { get; set; }
        private ClientRepository ClientRepository { get; set; }
        private WayBillRepository WayBillRepository { get; set; }
        private AccumRegisterRepository AccumRegisterRepository { get; set; }
    }
}
