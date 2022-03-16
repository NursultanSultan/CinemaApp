using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs.LanguageDtos
{
    public class LangCreateDto
    {
        [Required]
        public string Lang { get; set; } // Language 

        [Required]
        public IFormFile LangIconFile { get; set; }
    }
}
