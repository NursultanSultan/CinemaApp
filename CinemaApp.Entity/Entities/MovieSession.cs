

using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class MovieSession 
    {
        public int Id { get; set; }

        public int MovieId { get; set; } 
        public Movie Movie { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }

    }
}
