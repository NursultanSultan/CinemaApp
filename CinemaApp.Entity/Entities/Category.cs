
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Category 
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImageURL { get; set; }
        public IFormFile CategoryPhoto { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }

        public bool IsDeleted { get; set; }
    }
}
