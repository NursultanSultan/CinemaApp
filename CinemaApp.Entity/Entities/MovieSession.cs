
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class MovieSession : IEntity
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }

        //public int CinemaId { get; set; }
        //public Cinema Cinema { get; set; }

        //public int FormatId { get; set; }
        //public Format Format { get; set; }

        //public int LanguageId { get; set; }
        //public Language Language { get; set; }
    }
}
