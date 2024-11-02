using Core.Models;

namespace TodoList.Models.Entities;

public class Todo : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Priority Priority { get; set; }
    public int CategoryId { get; set; }
    public bool Completed { get; set; }
    public Category? Category { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }

    public Todo()
    {
        Id = Guid.NewGuid();
        Title = string.Empty;
        Description = string.Empty;
        CreatedDate = DateTime.UtcNow;
        Priority = Priority.Normal;
        Completed = false;
        UserId = string.Empty;
    }

    public Todo(Guid id, string title, string description, DateTime startDate, DateTime endDate, DateTime createdDate, Priority priority, int categoryId, bool completed, Category category, string userId, User user) : this()
    {
        Id = id;
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        CreatedDate = createdDate;
        Priority = priority;
        CategoryId = categoryId;
        Completed = completed;
        Category = category;
        UserId = userId;
        User = user;
    }
}
