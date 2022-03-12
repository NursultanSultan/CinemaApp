using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs
{
    public class FavoriteAddDto
    {
        public string UserId { get; set; }
        public List<int> MovieIds { get; set; }
        public List<Movie> Movies { get; set; }

        public bool IsFavorite { get; set; }
    }

}
