using CinemaApp.Business.DTOs.CategoryDtos;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Interfaces
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryReadDto>> GetAllAsync();
        Task<Category> GetAsync(int id);
        Task CreateAsync(CategoryCreateDto createDto);
        CategoryUpdateDto Update(int id);
        Task UpdateAsync(int id, CategoryUpdateDto updateDto);
        Task RemoveAsync(int id);
    }
}
