using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs.FormatDtos
{
    public class FormatCreateDto
    {
        [Required]
        public string FormatType { get; set; }

        [Required]
        public IFormFile FormatIconFile { get; set; }
    }
}
