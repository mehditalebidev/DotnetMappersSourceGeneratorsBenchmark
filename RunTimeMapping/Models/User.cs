﻿using System.ComponentModel;

namespace RunTimeMapping.Models;

public class User
{
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public int Age { get; set; }
    public Address? Address { get; set; }
}