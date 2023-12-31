﻿namespace StoreCS.Entities;

public class Client
{
    public int Id { get; set; }

    public string? FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;

    public DateTime? BirthDate { get; set; }
    public DateTime? Registered { get; set; }

  
    public List<Order>? Orders { get; set; }
}
