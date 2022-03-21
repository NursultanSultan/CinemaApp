using AutoMapper;
using CinemaApp.Business.DTOs.MovieDtos;
using CinemaApp.Business.Exceptions.FileExceptions;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            

            string root = Path.Combine(_env.WebRootPath, "assets", "image");

           

            string PosterFileName = await FileUpload(createDto.PosterFile, root);
            string BackgroundFileName = await FileUpload(createDto.BackgroundImgFile, root);

            movie.PosterUrl = PosterFileName;
            movie.BackgroundImgUrl = BackgroundFileName;

            /*File upload end*/

            await _unitOfWork.movieRepository.CreateAsync(movie);
            await _unitOfWork.SavechangeAsync();


            Movie CreatedMovie = await _unitOfWork.movieRepository
                                        .GetAsync(m => m.MovieName == createDto.MovieName && m.Director == createDto.Director);
            
            await CategoryCreateRelation(createDto.CategoryIds, createDto, CreatedMovie);
            await CinemaCreateRelation(createDto.CinemaIds, createDto, CreatedMovie);
            await LanguageCreateRelation(createDto.LanguageIds, createDto, CreatedMovie);
            await FormatCreateRelation(createDto.FormatIds, createDto, CreatedMovie);

            await _unitOfWork.SavechangeAsync();
        }

        public async Task<string> FileUpload(IFormFile file ,string root )
        {
            if (!file.CheckFileType("image/"))
            {
                throw new FileTypeException("File must be image type");
            }
            if (!file.CheckFileSize(2000))
            {
                throw new FileTypeException("File must be less than 300kb");
            }

            string FileName = await file.SaveFileAsync(root);
            return FileName;
        }

        public async Task CategoryCreateRelation(List<int> CategoryIds , MovieCreateDto createDto ,Movie CreatedMovie)
        {
            foreach (var id in createDto.CategoryIds)
            {
                MovieCategory movieCategory = new MovieCategory()
                {
                    CategoryId = id,
                    MovieId = CreatedMovie.Id

                };
                //movie.MovieCategories.Add(movieCategory);
                await _unitOfWork.movieCategoryRepository.CreateAsync(movieCategory);
            }
        }

        public async Task CinemaCreateRelation(List<int> CinemaIds, MovieCreateDto createDto, Movie CreatedMovie)
        {
            foreach (var id in createDto.CinemaIds)
            {
                MovieCinema movieCinema = new MovieCinema()
                {
                    CinemaId = id,
                    MovieId = CreatedMovie.Id

                };
                //movie.MovieCategories.Add(movieCategory);
                await _unitOfWork.movieCinemaRepository.CreateAsync(movieCinema);
            }
        }

        public async Task LanguageCreateRelation(List<int> LanguageIds, MovieCreateDto createDto, Movie CreatedMovie)
        {
            foreach (var id in createDto.LanguageIds)
            {
                MovieLanguage movieLanguage = new MovieLanguage()
                {
                    LanguageId = id,
                    MovieId = CreatedMovie.Id

                };
                //movie.MovieCategories.Add(movieCategory);
                await _unitOfWork.movieLanguageRepository.CreateAsync(movieLanguage);
            }
        }

        public async Task FormatCreateRelation(List<int> FormatIds, MovieCreateDto createDto, Movie CreatedMovie)
        {
            foreach (var id in createDto.FormatIds)
            {
                MovieFormat movieFormat = new MovieFormat()
                {
                    FormatId = id,
                    MovieId = CreatedMovie.Id

                };
                //movie.MovieCategories.Add(movieCategory);
                await _unitOfWork.movieFormatRepository.CreateAsync(movieFormat);
            }
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

        public async Task RemoveAsync(int id)
        {
            var dbMovie = await _unitOfWork.movieRepository
                                        .GetAsync(c => c.Id == id);

            if (dbMovie == null) throw new NullReferenceException();

            dbMovie.IsDeleted = true;

            await _unitOfWork.SavechangeAsync();
        }

        public MovieUpdateDto Update(int id) 
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, MovieUpdateDto updateDto)
        {
            var dbMovie = await _unitOfWork.movieRepository
                                        .GetAsync(c => c.Id == id);

            if (dbMovie == null) throw new NullReferenceException();

            if (updateDto.PosterFile != null)
            {
                /*File upload start*/
                //if (!updateDto.PosterFile.CheckFileType("image/"))
                //{
                //    throw new FileTypeException("File must be image type");
                //}
                //if (!updateDto.PosterFile.CheckFileSize(300))
                //{
                //    throw new FileTypeException("File must be less than 300kb");
                //}


                string root = Path.Combine(_env.WebRootPath, "assets", "image");
                string FileName = dbMovie.PosterUrl;
                string resultPath = Path.Combine(root, FileName);

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                //string UpdatedFileName = await updateDto.PosterFile.SaveFileAsync(root);

                string UpdatedFileName = await FileUpload(updateDto.PosterFile, root);
                dbMovie.PosterUrl = UpdatedFileName;

                /*File upload end*/
            }

            dbMovie.MovieName = updateDto.MovieName != null ? updateDto.MovieName : dbMovie.MovieName;
            dbMovie.TrailerUrl = updateDto.TrailerUrl != null ? updateDto.TrailerUrl : dbMovie.TrailerUrl;
            dbMovie.AboutContent = updateDto.AboutContent != null ? updateDto.AboutContent : dbMovie.AboutContent;
            dbMovie.ImdbPoint = updateDto.ImdbPoint != 0 ? updateDto.ImdbPoint : dbMovie.ImdbPoint;
            dbMovie.AgeLimit = updateDto.AgeLimit != 0 ? updateDto.AgeLimit : dbMovie.AgeLimit;
            dbMovie.Country = updateDto.Country != null ? updateDto.Country : dbMovie.Country;
            dbMovie.Director = updateDto.Director != null ? updateDto.Director : dbMovie.Director;
            dbMovie.Duration = updateDto.Duration != 0 ? updateDto.Duration : dbMovie.Duration;


            await _unitOfWork.SavechangeAsync();
        }
    }
}
