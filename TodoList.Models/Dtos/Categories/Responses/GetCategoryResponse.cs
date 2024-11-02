using TodoList.Models.Entities;

public sealed record GetCategoryResponse(int Id, string Name, DateTime CreatedDate, DateTime? UpdatedDate, List<Todo>? Todos);