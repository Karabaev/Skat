namespace DomainModel.Logic.XML
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public enum XmlTags
    {
        Document, // корень файла выгрузки 
        TradeObjects, // список ТО
        TradeObject, // ТО
        Code, // Код сущности
        Name, // Название сущности
        GLN, // GLN сущности
        FtpLogin, // Логин фтп ТО
        FtpPassword, // Пароль фтп ТО
        LocalFolder, // Локальная папка ТО
        Address, // адрес ТО
        ClientCode, // Код клиента ТО
        Clients, // список клиентов
        Client, // клиент
        INN, // ИНН контрагента
        KPP, // КПП контрагента
        Suppliers, // список постащиков
        Supplier, // поставщик
        Roaming, // роуминг
        NUMBER, // номер накладной 
        DATE, // дата накладной
        HEAD, // заголовок накладной
        BUYER, // покупатель накладной
        SUPPLIER, // поставщик накладной
        DELIVERYPLACE, // ТО накладной
        WayBills, // накладные для выгрузки
        WayBill, // накладная для выгрузки
        Number,
        SupplierCode,
        DocumentDate,
        DownloadDate,
        RegisterRecords, // блок записей из регистра накопления.
        RegisterRecord, // зпись из регистра накопления.
        WayBillCode, // код накладной в записи регистра
        TotalAmount, // общее количество накладных
        RoamingAmount, // количество роуминговых накладных
        DateTime // дата/время записи
    }

    public static class XmlParser
    {
        static XmlParser()
        {
            XmlParser.XmlTagNames = new Dictionary<XmlTags, string>();
            XmlParser.XmlTagNames.Add(XmlTags.Document, XmlTags.Document.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.TradeObjects, XmlTags.TradeObjects.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.TradeObject, XmlTags.TradeObject.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Code, XmlTags.Code.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Name, XmlTags.Name.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.GLN, XmlTags.GLN.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.FtpLogin, XmlTags.FtpLogin.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.FtpPassword, XmlTags.FtpPassword.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.LocalFolder, XmlTags.LocalFolder.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Address, XmlTags.Address.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.ClientCode, XmlTags.ClientCode.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Clients, XmlTags.Clients.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Client, XmlTags.Client.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.INN, XmlTags.INN.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.KPP, XmlTags.KPP.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Suppliers, XmlTags.Suppliers.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Supplier, XmlTags.Supplier.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Roaming, XmlTags.Roaming.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.NUMBER, XmlTags.NUMBER.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.DATE, XmlTags.DATE.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.HEAD, XmlTags.HEAD.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.BUYER, XmlTags.BUYER.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.SUPPLIER, XmlTags.SUPPLIER.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.DELIVERYPLACE, XmlTags.DELIVERYPLACE.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.WayBills, XmlTags.WayBills.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.WayBill, XmlTags.WayBill.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.Number, XmlTags.Number.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.SupplierCode, XmlTags.SupplierCode.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.DocumentDate, XmlTags.DocumentDate.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.DownloadDate, XmlTags.DownloadDate.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.RegisterRecords, XmlTags.RegisterRecords.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.RegisterRecord, XmlTags.RegisterRecord.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.WayBillCode, XmlTags.WayBillCode.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.TotalAmount, XmlTags.TotalAmount.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.RoamingAmount, XmlTags.RoamingAmount.ToString());
            XmlParser.XmlTagNames.Add(XmlTags.DateTime, XmlTags.DateTime.ToString());
        }

        public static XmlElement GetXmlNode(XmlElement curNode, XmlTags tag, int entranceNumber = 0)
        {
            try
            {
                var nodes = curNode.GetElementsByTagName(XmlParser.XmlTagNames[tag]);

                if (nodes.Count == 0)
                {
                    return null;
                }

                return (XmlElement)nodes[entranceNumber];
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static XmlNodeList GetXmlNodes(XmlElement curNode, XmlTags tag)
        {
            try
            {
                return curNode.GetElementsByTagName(XmlParser.XmlTagNames[tag]);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static string GetTagValue(XmlElement curNode, XmlTags tag, int entranceNumber = 0)
        {
            try
            {
                var nodes = curNode.GetElementsByTagName(XmlParser.XmlTagNames[tag]);

                if (nodes.Count == 0)
                {
                    return null;
                }

                return nodes[entranceNumber].InnerText;
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        public static Dictionary<XmlTags, string> XmlTagNames { get; private set; }
    }
}
