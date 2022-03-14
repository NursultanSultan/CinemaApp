
using CinemaApp.Business.DTOs;
using CinemaApp.Business.DTOs.MovieDtos;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieReadDto>> GetAllAsync();
        Task<Movie> GetAsync(int id);
        Task CreateAsync(MovieCreateDto createDto);
        MovieUpdateDto Update(int id);
        Task UpdateAsync(int id, MovieUpdateDto updateDto);
        Task RemoveAsync(int id);
    }
}
