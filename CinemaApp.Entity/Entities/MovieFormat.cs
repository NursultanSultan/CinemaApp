
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class MovieFormat :IEntity
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int FormatId { get; set; }
        public Format Format { get; set; }
    }
}
