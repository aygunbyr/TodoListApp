namespace TodoList.Models.Dtos.Categories.Responses;

public sealed record CreateCategoryResponse(int Id, string Name, DateTime CreatedDate);
