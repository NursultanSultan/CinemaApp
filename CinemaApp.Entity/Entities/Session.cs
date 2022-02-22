
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Session : IEntity
    {
        public int Id { get; set; }

        public DateTime SessionTime { get; set; }

        public ICollection<MovieSession> MovieSessions { get; set; }

        public bool IsDeleted { get; set; }
    }
}
