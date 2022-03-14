using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs.LanguageDtos
{
    public class LangReadDto
    {
        public int Id { get; set; }

        public string Lang { get; set; } // Language

        public string LangIconUrl { get; set; }
    }
}
