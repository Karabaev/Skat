namespace DomainModel.Model
{
    public interface ICounteragent : IEntity
    {
        string Name { get; set; }
        string GLN { get; set; }
        string INN { get; set; }
        string KPP { get; set; }
    }
}
