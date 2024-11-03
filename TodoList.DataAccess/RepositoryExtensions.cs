using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.DataAccess.Abstracts;
using TodoList.DataAccess.Concretes;
using TodoList.DataAccess.Contexts;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositoryExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        services.AddScoped<ITodoRepository, EfTodoRepository>();

        return services;
    }
}