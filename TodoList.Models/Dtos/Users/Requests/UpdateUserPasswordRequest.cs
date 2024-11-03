namespace TodoList.Models.Dtos.Users.Requests;

public sealed record UpdateUserPasswordRequest(string CurrentPassword, string NewPassword, string NewPasswordAgain);
