namespace Core.Models;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime? UpdatedDate { get; set; }
}
