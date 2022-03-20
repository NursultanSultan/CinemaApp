using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs
{
    public class HomeDto
    {
        public List<Movie> Movies { get; set; }
        public List<Movie> OwlMovies { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Language> Languages { get; set; }
        public List<Category> Categories { get; set; }
        public List<News> News { get; set; }
    }
}
