namespace VideoStore.Domain.Models
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        bool Removed { get; set; }
    }
}
