
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class MovieCinema : IEntity
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
    }
}
