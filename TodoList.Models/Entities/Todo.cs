﻿using Core.Models;

namespace TodoList.Models.Entities;

public class Todo : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Priority Priority { get; set; }
    public int CategoryId { get; set; }
    public bool Completed { get; set; }
    public Category? Category { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
}
