namespace TodoList.Models.Dtos.Categories.Responses;

public sealed record UpdateCategoryResponse(int Id, string Name, DateTime CreatedDate, DateTime UpdatedDate);
