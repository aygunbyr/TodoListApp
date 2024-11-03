using Core.Exceptions;
using TodoList.Models.Entities;

namespace TodoList.Service.Rules;

public class TodoBusinessRules
{
    public virtual void TodoIsNullCheck(Todo todo)
    {
        if (todo is null)
        {
            throw new NotFoundException("Belirtilen yapılacak iş bulunamadı.");
        }
    }
}
