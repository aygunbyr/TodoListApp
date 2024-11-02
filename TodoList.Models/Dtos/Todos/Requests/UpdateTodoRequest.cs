namespace TodoList.Models.Dtos.Todos.Requests;

public sealed record UpdateTodoRequest(Guid Id, string Title, string Description, DateTime StartDate, DateTime EndDate, int Priority, int CategoryId, bool Completed);