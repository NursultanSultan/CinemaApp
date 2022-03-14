using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaApp.Business.DTOs.MovieDtos
{
    public class MovieReadDto
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public string PosterUrl { get; set; }

        public string BackgroundImgUrl { get; set; }

        //public string TrailerUrl { get; set; }

        //public decimal Price { get; set; }

        //public string AboutContent { get; set; }

        public double ImdbPoint { get; set; }

        //public int AgeLimit { get; set; }

        //public string Country { get; set; }

        public string Director { get; set; }  // Rejissor

        //public int Duration { get; set; }  // Filmin muddeti
    }
}
