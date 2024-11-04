using BlogSite.Service.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoList.Service.Abstracts;
using TodoList.Service.Concretes;
using TodoList.Service.Profiles;
using TodoList.Service.Rules;

namespace TodoList.Service;

public static class ServiceExtensions
{
    public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITodoService, TodoService>();
        services.AddScoped<RoleService>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<TodoBusinessRules>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
