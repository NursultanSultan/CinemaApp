using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs.FormatDtos
{
    public class FormatUpdateDto
    {
        public int Id { get; set; }

        public string FormatType { get; set; }

        public IFormFile FormatIconFile { get; set; }
    }
}
