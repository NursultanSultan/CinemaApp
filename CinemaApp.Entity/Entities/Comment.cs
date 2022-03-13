
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Comment 
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
        public IdentityUser User { get; set; }

        public string Content { get; set; }

        public DateTime dateTime { get; set; }
    }
}
