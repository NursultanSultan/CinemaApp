using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs
{
    public class ContactUsCreateDto
    {
        [Required,  DataType(DataType.EmailAddress)]
        public string UserMail { get; set; }

        [Required ,MaxLength(255)]
        public string Subject { get; set; }

        [Required, MaxLength(255)]
        public string Message { get; set; }
    }
}
