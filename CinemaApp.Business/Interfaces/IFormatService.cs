using CinemaApp.Business.DTOs.FormatDtos;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Interfaces
{
    public interface IFormatService
    {
        Task<IEnumerable<FormatReadDto>> GetAllAsync();
        Task<Format> GetAsync(int id);
        Task CreateAsync(FormatCreateDto createDto);
        FormatUpdateDto Update(int id);
        Task UpdateAsync(int id, FormatUpdateDto updateDto);
        Task RemoveAsync(int id);
    }
}
