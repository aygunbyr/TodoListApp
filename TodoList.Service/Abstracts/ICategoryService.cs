using Core.Responses;
using TodoList.Models.Dtos.Categories.Requests;
using TodoList.Models.Dtos.Categories.Responses;

namespace TodoList.Service.Abstracts;

public interface ICategoryService
{
    Task<ReturnModel<CreateCategoryResponse>> AddAsync(CreateCategoryRequest request);
    Task<ReturnModel<List<GetCategoryResponse>>> GetAllAsync();
    Task<ReturnModel<GetCategoryResponse?>> GetByIdAsync(int id);
    Task<ReturnModel<GetCategoryResponse?>> RemoveAsync(int id);
    Task<ReturnModel<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest request);

}
