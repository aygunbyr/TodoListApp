using BlogSite.Service.Concretes;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Service.Abstracts;
using TodoList.Service.Concretes;
using TodoList.Service.Profiles;

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

        return services;
    }
}
