using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Business.DTOs.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public IFormFile CategoryPhoto { get; set; }
    }
}
