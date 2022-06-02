﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingCartApp.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
