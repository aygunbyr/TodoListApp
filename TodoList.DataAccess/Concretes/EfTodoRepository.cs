using Core.Repositories;
using TodoList.DataAccess.Abstracts;
using TodoList.DataAccess.Contexts;
using TodoList.Models.Entities;

namespace TodoList.DataAccess.Concretes;

public class EfTodoRepository(BaseDbContext context) : EfRepositoryBase<BaseDbContext, Todo, Guid>(context), ITodoRepository
{
}
