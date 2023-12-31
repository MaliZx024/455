﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDTO
{
    [Required(ErrorMessage = "Please enter a username")]
    [MinLength(3, ErrorMessage = "Please enter a username at least 3 characters")]
    public string? Username { get; set; }


    [MinLength(3, ErrorMessage = "Please enter a password at least 3 characters")]
    public required string Password { get; set; }
}
