namespace DomainModel.Model
{
    public interface IEntity
    {
        int ID { get; set; }

        void Reinitialization(IEntity other);
        bool Equals(object other);
        bool LikeAs(IEntity other);
        int GetHashCode();
        string ToString();
    }
}
