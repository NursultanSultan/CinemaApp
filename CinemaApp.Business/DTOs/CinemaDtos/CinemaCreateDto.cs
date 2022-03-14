using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaApp.Business.DTOs.CinemaDtos
{
    public class CinemaCreateDto
    {
        [Required]
        public string CinemaName { get; set; }

        [Required]
        public IFormFile CinemaPosterPhoto { get; set; }

        [Required , MaxLength(255)]
        public string ShortContent { get; set; }

        [Required]
        public string OurAdress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string EMail { get; set; }

        [Required]
        public string WorkingHour { get; set; } 

        [Required]
        public string MapLocation { get; set; }

    }
}
