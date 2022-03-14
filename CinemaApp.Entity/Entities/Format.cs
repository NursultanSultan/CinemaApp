
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Format
    {
        public int Id { get; set; }

        public string FormatType { get; set; }

        public string FormatIconUrl { get; set; }
        public IFormFile FormatIconFile { get; set; } 

        public ICollection<MovieFormat> MovieFormats { get; set; }

        public bool IsDeleted { get; set; }
    }
}
