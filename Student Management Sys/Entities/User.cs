﻿using System.Text.Json.Serialization;

namespace Student_Management_Sys.Entities;


public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
}