﻿namespace TodoList.Models.Dtos.Users.Requests;
public sealed record UpdateUserRequest(string FirstName, string LastName, string Username);