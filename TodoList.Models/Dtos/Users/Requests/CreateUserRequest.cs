namespace TodoList.Models.Dtos.Users.Requests;

public sealed record CreateUserRequest(string FirstName, string LastName, string Email, string Password, string Username);
