using Core.Repositories;
using TodoList.DataAccess.Abstracts;
using TodoList.DataAccess.Contexts;
using TodoList.Models.Entities;

namespace TodoList.DataAccess.Concretes;

public class EfCategoryRepository(BaseDbContext context) : EfRepositoryBase<BaseDbContext, Category, int>(context), ICategoryRepository
{
}