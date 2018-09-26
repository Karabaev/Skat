﻿namespace DomainModel.Logic.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;

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
        DELIVERYPLACE // ТО накладной
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

        private static Dictionary<XmlTags, string> XmlTagNames { get; set; }
    }
}
