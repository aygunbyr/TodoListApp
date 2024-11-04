using AutoMapper;
using System.Diagnostics.Metrics;
using TodoList.Models.Dtos.Categories.Requests;
using TodoList.Models.Dtos.Categories.Responses;
using TodoList.Models.Dtos.Todos.Requests;
using TodoList.Models.Dtos.Todos.Responses;
using TodoList.Models.Entities;

namespace TodoList.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, GetCategoryResponse>();
        CreateMap<Category, CreateCategoryResponse>();
        CreateMap<Category, UpdateCategoryResponse>();

        CreateMap<CreateTodoRequest, Todo>();
        CreateMap<UpdateTodoRequest, Todo>();
        CreateMap<Todo, GetTodoResponse>()
            .ForMember(response => response.UserName,
                       memberOptions => memberOptions.MapFrom(todo => todo.User.UserName))
            .ForMember(response => response.CategoryName,
                       memberOptions => memberOptions.MapFrom(todo => todo.Category.Name));
        CreateMap<Todo, CreateTodoResponse>();
        CreateMap<Todo, UpdateTodoResponse>();
    }
}
