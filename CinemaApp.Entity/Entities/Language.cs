
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public string Lang { get; set; } // Language

        public string LangIconUrl { get; set; }
        public IFormFile LangIconFile { get; set; }

        public ICollection<MovieLanguage> MovieLanguages { get; set; }


        public bool IsDeleted { get; set; }
    }
}
