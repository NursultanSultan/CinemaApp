
using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Format : IEntity
    {
        public int Id { get; set; }

        public string FormatType { get; set; }

        public ICollection<MovieFormat> MovieFormats { get; set; }

        public bool IsDeleted { get; set; }
    }
}
