using AutoMapper;
using Core.Responses;
using TodoList.DataAccess.Abstracts;
using TodoList.Models.Dtos.Categories.Requests;
using TodoList.Models.Dtos.Categories.Responses;
using TodoList.Models.Entities;
using TodoList.Service.Abstracts;
using TodoList.Service.Rules;

namespace TodoList.Service.Concretes;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules businessRules) : ICategoryService
{
    public async Task<ReturnModel<CreateCategoryResponse>> AddAsync(CreateCategoryRequest request)
    {
        Category createdCategory = mapper.Map<Category>(request);
        
        await categoryRepository.AddAsync(createdCategory);

        CreateCategoryResponse response = mapper.Map<CreateCategoryResponse>(createdCategory);

        return new ReturnModel<CreateCategoryResponse>
        {
            Data = response,
            Message = "Kategori eklendi.",
            StatusCode = 201,
            Success = true
        };
    }

    public async Task<ReturnModel<List<GetCategoryResponse>>> GetAllAsync()
    {
        List<Category> categories = await categoryRepository.GetAllAsync();
        List<GetCategoryResponse> response = mapper.Map<List<GetCategoryResponse>>(categories);

        return new ReturnModel<List<GetCategoryResponse>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<GetCategoryResponse?>> GetByIdAsync(int id)
    {
        Category? category = await categoryRepository.GetByIdAsync(id);

        businessRules.CategoryIsNullCheck(category);

        GetCategoryResponse response = mapper.Map<GetCategoryResponse>(category);

        return new ReturnModel<GetCategoryResponse?> { 
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<GetCategoryResponse?>> RemoveAsync(int id)
    {
        Category? category = await categoryRepository.GetByIdAsync(id);

        businessRules.CategoryIsNullCheck(category);

        Category deletedCategory = await categoryRepository.RemoveAsync(category);

        GetCategoryResponse response = mapper.Map<GetCategoryResponse>(category);

        return new ReturnModel<GetCategoryResponse?> 
        {
            Data = response,
            Message = "Kategori silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<UpdateCategoryResponse>> UpdateAsync(UpdateCategoryRequest request)
    {
        Category? category = await categoryRepository.GetByIdAsync(request.Id);

        businessRules.CategoryIsNullCheck(category);

        Category newCategory = new Category
        {
            Id = request.Id,
            Name = request.Name,
        };

        Category updatedCategory = await categoryRepository.UpdateAsync(newCategory);

        UpdateCategoryResponse response = mapper.Map<UpdateCategoryResponse>(updatedCategory);

        return new ReturnModel<UpdateCategoryResponse>
        {
            Data = response,
            Message = "Kategori güncellendi.",
            StatusCode = 200,
            Success = true
        };
    }
}
