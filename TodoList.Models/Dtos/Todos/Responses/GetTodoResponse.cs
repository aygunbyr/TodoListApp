using TodoList.Models.Entities;

namespace TodoList.Models.Dtos.Todos.Responses;

public sealed record GetTodoResponse
{
    public GetTodoResponse() { }

    public GetTodoResponse(Guid id, string title, string description, DateTime startDate, DateTime endDate, DateTime createdDate, DateTime? updatedDate, int priority, string categoryName, bool completed, string userName)
    {
        Id = id;
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        Priority = priority;
        CategoryName = categoryName;
        Completed = completed;
        UserName = userName;
    }

    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime? UpdatedDate { get; init; }
    public int Priority { get; init; }
    public string CategoryName { get; init; }
    public bool Completed { get; init; }
    public string UserName { get; init; }
}
