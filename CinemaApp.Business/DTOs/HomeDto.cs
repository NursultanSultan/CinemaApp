using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs
{
    public class HomeDto
    {
        public List<Movie> Movies { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Language> Languages { get; set; }
    }
}
