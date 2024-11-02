namespace TodoList.Models.Dtos.Todos.Responses;

public sealed record UpdateTodoResponse(Guid Id, string Title, string Description, DateTime StartDate, DateTime EndDate, DateTime CreatedDate, DateTime UpdatedDate, int Priority, int CategoryId, bool Completed, string UserId);
