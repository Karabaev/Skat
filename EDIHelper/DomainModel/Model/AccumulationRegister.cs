namespace DomainModel.Model
{
    using System;

    public class AccumulationRegister : IEntity
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int Value { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsRoaming { get; set; }
        public int WaybillID { get; set; }

        public bool LikeAs(IEntity other)
        {
            throw new NotImplementedException();
        }

        public void Reinitialization(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
