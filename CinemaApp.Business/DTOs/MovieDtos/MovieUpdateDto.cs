using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs.MovieDtos
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public IFormFile PosterFile { get; set; }

        public IFormFile BackgroundImgFile { get; set; }

        public string TrailerUrl { get; set; }

        public decimal Price { get; set; }

        public string AboutContent { get; set; }

        public double ImdbPoint { get; set; }

        public int AgeLimit { get; set; }

        public string Country { get; set; }

        public string Director { get; set; }  // Rejissor

        public int Duration { get; set; }  // Filmin muddeti
    }
}
