
using Core.Models;

namespace TodoList.Models.Entities;

public class Category : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public List<Todo>? Todos { get; set; }

    public Category()
    {
    }

    public Category(int id, string name) : this()
    {
        Id = id;
        Name = name;
        CreatedDate = DateTime.UtcNow;
    }
}
