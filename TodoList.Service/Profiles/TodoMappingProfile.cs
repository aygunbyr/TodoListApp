using AutoMapper;
using TodoList.Models.Dtos.Todos.Requests;
using TodoList.Models.Dtos.Todos.Responses;
using TodoList.Models.Entities;

namespace TodoList.Service.Profiles;

public class TodoMappingProfile : Profile
{
    public TodoMappingProfile()
    {
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
