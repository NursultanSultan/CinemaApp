using CinemaApp.Business.DTOs.CinemaDtos;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<CinemaReadDto>> GetAllAsync();
        Task<Cinema> GetAsync(int id);
        Task CreateAsync(CinemaCreateDto createDto);
        CinemaUpdateDto Update(int id);
        Task UpdateAsync(int id, CinemaUpdateDto updateDto);
        Task RemoveAsync(int id);
    }
}
