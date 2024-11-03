using Core.Exceptions;
using TodoList.Models.Entities;

namespace TodoList.Service.Rules;

public class CategoryBusinessRules
{
    public virtual void CategoryIsNullCheck(Category category)
    {
        if(category is null)
        {
            throw new NotFoundException("Belirtilen kategori bulunamadı.");
        }
    }
}
