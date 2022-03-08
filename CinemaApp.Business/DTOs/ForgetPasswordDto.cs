using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs
{
    public class ForgetPasswordDto
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
