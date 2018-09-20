namespace DomainModel.Model
{
    using System;
    using System.ComponentModel;

    public class Supplier : ICounteragent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GLN { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        [DisplayName("Roaming?")]
        public bool? IsRoaming { get; set; }

        public void Reinitialization(IEntity other)
        {
            if (!(other is Supplier newSupplier))
            {
                return;
            }

            this.Name = newSupplier.Name;
            this.GLN = newSupplier.GLN;
            this.INN = newSupplier.INN;
            this.KPP = newSupplier.KPP;
            this.IsRoaming = newSupplier.IsRoaming;
        }

        public override bool Equals(object other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool LikeAs(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
