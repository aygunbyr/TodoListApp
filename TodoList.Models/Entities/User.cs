using Core.Models;
using Microsoft.AspNetCore.Identity;

namespace TodoList.Models.Entities;

public class User : IdentityUser, IEntity<string>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public List<Todo>? Todos { get; set; }
}
