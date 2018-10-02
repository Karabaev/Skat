namespace DomainModel.Model
{
    using System;
    using System.ComponentModel;

    public class Waybill : IEntity
    {
        public int ID { get; set; }
      //  public string ExCode { get; set; }
        public string Number { get; set; }
        public int SupplierID { get; set; }
        public int ClientID { get; set; }
        public DateTime DocumentDate { get; set; }
        public DateTime DownloadDate { get; set; }

        public void Reinitialization(IEntity other)
        {
            if (!(other is Waybill newWayBill))
            {
                return;
            }

            this.Number = newWayBill.Number;
            this.SupplierID = newWayBill.SupplierID;
            this.ClientID = newWayBill.ClientID;
            this.DocumentDate = newWayBill.DocumentDate;
            this.DownloadDate = newWayBill.DownloadDate;
        }

        public override bool Equals(object other)
        {
            return other is Waybill wb && this.ID == wb.ID && this.LikeAs(wb);
        }

        public bool LikeAs(IEntity other)
        {
            return other is Waybill wb &&
                    this.Number == wb.Number &&
                    this.SupplierID == wb.SupplierID &&
                    this.ClientID == wb.ClientID &&
                    this.DocumentDate == wb.DocumentDate &&
                    this.DownloadDate == wb.DownloadDate;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, Number: {1}, SupplierID: {2}, ClientID: {3}, DocumentDate: {4}, DownloadDate: {5}",
                this.ID, this.Number, this.SupplierID, this.ClientID, this.DocumentDate, this.DownloadDate);
        }
    }
}
