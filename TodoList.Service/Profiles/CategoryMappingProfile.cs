using AutoMapper;
using System.Diagnostics.Metrics;
using TodoList.Models.Dtos.Categories.Requests;
using TodoList.Models.Dtos.Categories.Responses;
using TodoList.Models.Entities;

namespace TodoList.Service.Profiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, GetCategoryResponse>();
        CreateMap<Category, CreateCategoryResponse>();
        CreateMap<Category, UpdateCategoryResponse>();
    }
}
