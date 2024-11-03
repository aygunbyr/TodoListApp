﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoList.Models.Entities;

namespace TodoList.DataAccess.Contexts;

public class BaseDbContext(DbContextOptions options) : IdentityDbContext<User, IdentityRole, string>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Todo> Todos { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}