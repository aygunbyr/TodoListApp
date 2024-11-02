namespace TodoList.Models.Dtos.Todos.Requests;

public sealed record CreateTodoRequest(string Title, string Description, DateTime StartDate, DateTime EndDate, int Priority, int CategoryId, bool Completed);
