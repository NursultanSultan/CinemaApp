using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaApp.Business.DTOs.MovieDtos
{
    public class MovieCreateDto
    {
        [Required , MaxLength(255)]
        public string MovieName { get; set; }

        [Required]
        public IFormFile PosterFile { get; set; }

        [Required]
        public IFormFile BackgroundImgFile { get; set; }

        [Required]
        public string TrailerUrl { get; set; }

        //[Required]
        //public decimal Price { get; set; }

        [Required, MaxLength(255)]
        public string AboutContent { get; set; }

        [Required]
        public double ImdbPoint { get; set; }

        [Required]
        public int AgeLimit { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Director { get; set; }  // Rejissor

        [Required]
        public int Duration { get; set; }  // Filmin muddeti

        public IEnumerable<Category> Categories { get; set; }
        [Required]
        public List<int> CategoryIds { get; set; }

        public IEnumerable<Cinema> Cinemas { get; set; }
        [Required]
        public List<int> CinemaIds { get; set; }

        public IEnumerable<Language> Languages { get; set; }
        [Required]
        public List<int> LanguageIds { get; set; }

        public IEnumerable<Format> Formats { get; set; }
        [Required]
        public List<int> FormatIds { get; set; }


    }
}
