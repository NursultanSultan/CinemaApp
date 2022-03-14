using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs.CinemaDtos
{
    public class CinemaUpdateDto
    {
        public int Id { get; set; }

        public string CinemaName { get; set; }

        public IFormFile CinemaPosterPhoto { get; set; }

        public string ShortContent { get; set; }

        public string OurAdress { get; set; }

        public string PhoneNumber { get; set; }

        public string EMail { get; set; }

        public string WorkingHour { get; set; }

        public string MapLocation { get; set; }
    }
}
