using AutoMapper;
using CinemaApp.Business.DTOs.MovieDtos;
using CinemaApp.Business.Exceptions.FileExceptions;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Hosting; 
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task CreateAsync(MovieCreateDto createDto)
        {
            Movie movie = new Movie
            {
                MovieName = createDto.MovieName,
                AboutContent = createDto.AboutContent,
                AgeLimit = createDto.AgeLimit,
                Country = createDto.Country,
                Director = createDto.Director,
                ImdbPoint = createDto.ImdbPoint,
                Duration = createDto.Duration,
                TrailerUrl = createDto.TrailerUrl
            };
            if (!createDto.PosterFile.CheckFileType("image/"))
            {
                throw new FileTypeException("File must be image type");
            }
            if (!createDto.PosterFile.CheckFileSize(300))
            {
                throw new FileTypeException("File must be less than 300kb");
            }

            if (!createDto.BackgroundImgFile.CheckFileType("image/"))
            {
                throw new FileTypeException("File must be image type");
            }
            if (!createDto.BackgroundImgFile.CheckFileSize(300))
            {
                throw new FileTypeException("File must be less than 300kb");
            }

            string root = Path.Combine(_env.WebRootPath, "assets", "image");
            string PosterFileName = await createDto.PosterFile.SaveFileAsync(root);
            string BackgroundFileName = await createDto.PosterFile.SaveFileAsync(root);
            movie.PosterUrl = PosterFileName;
            movie.BackgroundImgUrl = BackgroundFileName;

            /*File upload end*/

            await _unitOfWork.movieRepository.CreateAsync(movie);
            await _unitOfWork.SavechangeAsync();

            Movie CreatedMovie = await _unitOfWork.movieRepository
                                        .GetAsync(m => m.MovieName == createDto.MovieName && m.Director == createDto.Director);
            MovieCategory movieCategory = new MovieCategory
            {
                MovieId = CreatedMovie.Id,
                CategoryId = createDto.CategoryId
            };
            await _unitOfWork.movieCategoryRepository.CreateAsync(movieCategory);
            await _unitOfWork.SavechangeAsync();
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
