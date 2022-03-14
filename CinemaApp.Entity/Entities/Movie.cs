
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Movie 
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public string PosterUrl { get; set; }
        public IFormFile PosterFile { get; set; }

        public string BackgroundImgUrl { get; set; }
        public IFormFile BackgroundImgFile { get; set; }

        public string TrailerUrl { get; set; }

        public decimal Price { get; set; } 

        public ICollection<MovieCinema> MovieCinemas { get; set; }

        public ICollection<MovieSession> MovieSessions { get; set; }

        public ICollection<MovieFormat> MovieFormats { get; set; }

        public ICollection<MovieLanguage> MovieLanguages { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }

        public ICollection<Comment> Comments { get; set; }



        public bool IsDeleted { get; set; }



        /* ------ About prop --------- */

        public DateTime InCinemasFrom { get; set; }  // Cinemalarda bawlama vaxt
        public DateTime InCinemasTo { get; set; }    // Cinemalarda bitme vaxti

        public string AboutContent { get; set; }

        public double ImdbPoint { get; set; }

        public int AgeLimit { get; set; }

        public string Country { get; set; }

        public string Director { get; set; }  // Rejissor

        public int Duration { get; set; }  // Filmin muddeti

        //public string Genre { get; set; }
    }
}
