using Core.Repositories;
using TodoList.Models.Entities;

namespace TodoList.DataAccess.Abstracts;

public interface ICategoryRepository : IAsyncRepository<Category,int>
{
}
