using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs.LanguageDtos
{
    public class LangUpdateDto
    {
        public int Id { get; set; }

        public string Lang { get; set; } // Language

        public IFormFile LangIconFile { get; set; }
    }
}
