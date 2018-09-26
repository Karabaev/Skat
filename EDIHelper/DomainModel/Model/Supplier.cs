namespace DomainModel.Model
{
    using System;
    using System.ComponentModel;

    public class Supplier : ICounteragent
    {
        public int ID { get; set; }
        public string ExCode { get; set; }
        public string Name { get; set; }
        public string GLN { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        [DisplayName("Roaming?")]
        public bool IsRoaming { get; set; }

        public void Reinitialization(IEntity other)
        {
            if (!(other is Supplier newSupplier))
            {
                return;
            }

            this.Name = newSupplier.Name;
            this.ExCode = newSupplier.ExCode;
            this.GLN = newSupplier.GLN;
            this.INN = newSupplier.INN;
            this.KPP = newSupplier.KPP;
            this.IsRoaming = newSupplier.IsRoaming;
        }

        public override bool Equals(object other)
        {
            Supplier supplier = other as Supplier;
            return supplier != null &&
                this.ID == supplier.ID &&
                this.Name == supplier.Name &&
                this.GLN == supplier.GLN &&
                this.INN == supplier.INN &&
                this.KPP == supplier.KPP &&
                this.IsRoaming == supplier.IsRoaming;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, ExCode: {1}, Name: {2}, GLN: {3}, INN: {4}, KPP: {5}, IsRoaming: {6}", 
                                this.ID, this.ExCode, this.Name, this.GLN, this.INN, this.KPP, this.IsRoaming);
        }

        public bool LikeAs(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
