
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Cinema 
    {
        public int Id { get; set; }

        public string CinemaName { get; set; }

        public string ShortContent { get; set; }

        public string CinemaPosterURL { get; set; }
        public IFormFile CinemaPosterPhoto { get; set; }

        public ICollection<Hall> Halls { get; set; }
        public ICollection<MovieCinema> MovieCinemas { get; set; }

        public string OurAdress { get; set; }

        public string PhoneNumber { get; set; }

        public string EMail { get; set; }

        public string WorkingHour { get; set; }

        public string MapLocation { get; set; }

        public bool IsDeleted { get; set; }
    }
}
