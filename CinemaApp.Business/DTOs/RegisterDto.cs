using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs
{
    public class RegisterDto
    {
        [Required , MaxLength(100)]
        public string Username { get; set; }

        [Required , MaxLength(255) , DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required , MaxLength(255) , DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password) , Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
