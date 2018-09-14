﻿namespace FTPGui.BusinessLogicLayer
{
    using System.Text;
    /// <summary>
    /// Данные для доступа к хранилищу FTP.
    /// </summary>
    public class FTPAccessData
    {
        public FTPAccessData(int id, string name, string gln, string login, string pass, string locFolder)
        {
            this.ID = id;
            this.ShopName = name;
            this.GLN = gln;
            this.Login = login;
            this.Password = pass;
            this.LocalFolder = locFolder;
        }

        /// <summary>
        /// ID.
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Название магазина.
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// GLN магазина.
        /// </summary>
        public string GLN { get; set; }
        /// <summary>
        /// Логин от сервера FTP.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль от сервера FTP.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Локальная папка для хранения файлов.
        /// </summary>
        public string LocalFolder { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("ID: {0}, Name: {1}", this.ID, this.ShopName);
            return result.ToString();
        }

        public override bool Equals(object other)
        {
            FTPAccessData otherData = other as FTPAccessData;
            
            if(otherData == null)
            {
                return false;
            }

            return (this.ID == otherData.ID) && this.LikeAs(otherData);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool LikeAs(FTPAccessData other)
        {
            return  (this.ShopName == other.ShopName) &&
                    (this.GLN == other.GLN) &&
                    (this.Login == other.Login) &&
                    (this.Password == other.Password) &&
                    (this.LocalFolder == other.LocalFolder);
        }
    }
}
