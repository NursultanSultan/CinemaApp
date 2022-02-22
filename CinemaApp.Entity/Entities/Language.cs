
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Language : IEntity
    {
        public int Id { get; set; }

        public string Lang { get; set; } // Language

        public ICollection<MovieLanguage> MovieLanguages { get; set; }

        public bool IsDeleted { get; set; }
    }
}
