
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class MovieLanguage : IEntity
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
