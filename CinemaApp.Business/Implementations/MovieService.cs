using CinemaApp.Business.DTOs.MovieDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class MovieService : IMovieService
    {
        public Task CreateAsync(MovieCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public MovieUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, MovieUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
