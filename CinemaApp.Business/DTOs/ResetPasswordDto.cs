using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs
{
    public class ResetPasswordDto
    {
        [Required, MaxLength(255), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(255), DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
