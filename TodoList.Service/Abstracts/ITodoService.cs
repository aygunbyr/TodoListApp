using Core.Responses;
using TodoList.Models.Dtos.Todos.Requests;
using TodoList.Models.Dtos.Todos.Responses;

namespace TodoList.Service.Abstracts;

public interface ITodoService
{
    Task<ReturnModel<CreateTodoResponse>> AddAsync(CreateTodoRequest request, string userId);
    Task<ReturnModel<List<GetTodoResponse>>> GetAllAsync();
    Task<ReturnModel<List<GetTodoResponse>>> GetTodosByUserIdAsync(string userId);
    Task<ReturnModel<List<GetTodoResponse>>> GetTodosByCategoryIdAsync(int categoryId);
    Task<ReturnModel<GetTodoResponse?>> GetByIdAsync(Guid id);
    Task<ReturnModel<GetTodoResponse>> RemoveAsync(Guid id);
    Task<ReturnModel<UpdateTodoResponse>> UpdateAsync(UpdateTodoRequest request);
    Task<ReturnModel<List<GetTodoResponse>>> GetTodosByFilterText(string filterText);
    Task<ReturnModel<List<GetTodoResponse>>> GetUsersTodosByFilterText(string filterText, string userId);
}
