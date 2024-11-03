using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models.Entities;

namespace TodoList.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(category => category.Id);

        builder.HasMany(category => category.Todos)
            .WithOne(todo => todo.Category)
            .HasForeignKey(todo => todo.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
