using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaApp.Business.DTOs.CategoryDtos
{
    public class CategoryCreateDto
    {
        [Required , MaxLength(255)]
        public string CategoryName { get; set; }

        [Required]
        public IFormFile CategoryPhoto { get; set; }

    }
}
