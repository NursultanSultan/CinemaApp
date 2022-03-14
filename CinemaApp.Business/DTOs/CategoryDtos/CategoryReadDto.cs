using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Business.DTOs.CategoryDtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImageURL { get; set; }
    }
}
