namespace TodoList.Models.Dtos.Todos.Responses;

public sealed record CreateTodoResponse(Guid Id, string Title, string Description, DateTime StartDate, DateTime EndDate, DateTime CreatedDate, int Priority, int CategoryId, bool Completed, string UserId);
