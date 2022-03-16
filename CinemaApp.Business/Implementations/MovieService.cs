using AutoMapper;
using CinemaApp.Business.DTOs.MovieDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class MovieService : IMovieService
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public Task CreateAsync(MovieCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieReadDto>> GetAllAsync()
        {
            var dbMovies = await _unitOfWork.movieRepository
                                        .GetAllAsync(c => c.IsDeleted == false);

            //List<CategoryReadDto> readVM = _mapper.Map<List<CategoryReadDto>>(dbCategories);
            List<MovieReadDto> movieDtos = new List<MovieReadDto>();

            foreach (var movie in dbMovies)
            {
                MovieReadDto readDto = new MovieReadDto
                {
                    Id = movie.Id,
                    MovieName = movie.MovieName,
                    BackgroundImgUrl = movie.BackgroundImgUrl,
                    Director = movie.Director,
                    PosterUrl = movie.PosterUrl,
                    ImdbPoint = movie.ImdbPoint
                };

                movieDtos.Add(readDto);
            }

            return movieDtos;
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
