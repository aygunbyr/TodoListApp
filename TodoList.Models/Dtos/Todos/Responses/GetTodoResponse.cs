using TodoList.Models.Entities;

namespace TodoList.Models.Dtos.Todos.Responses;

public sealed record GetTodoResponse(Guid Id, string Title, string Description, DateTime StartDate, DateTime EndDate, DateTime CreatedDate, DateTime? UpdatedDate, int Priority, int CategoryId, bool Completed, Category? Category, string UserId, User? User);

