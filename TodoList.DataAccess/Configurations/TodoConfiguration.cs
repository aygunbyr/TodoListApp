using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models.Entities;

namespace TodoList.DataAccess.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todos").HasKey(todo => todo.Id);

        builder.HasOne(todo => todo.Category)
            .WithMany(category => category.Todos)
            .HasForeignKey(todo => todo.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(todo => todo.User)
            .WithMany(user => user.Todos)
            .HasForeignKey(todo => todo.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x => x.User).AutoInclude();
    }
}