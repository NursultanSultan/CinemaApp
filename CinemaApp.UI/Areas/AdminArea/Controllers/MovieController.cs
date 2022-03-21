using AutoMapper;
using CinemaApp.Business.DTOs;
using CinemaApp.Business.DTOs.MovieDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaApp.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller 
    {
        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }
        private IMovieService _movieService { get; }

        public MovieController(IUnitOfWork unitOfWork, IMapper mapper
                , IWebHostEnvironment env, IMovieService movieService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _unitOfWork.categoryRepository.GetAllAsync();
            var cinemas = await _unitOfWork.cinemaRepository.GetAllAsync();
            var languages = await _unitOfWork.languageRepository.GetAllAsync();
            var formats = await _unitOfWork.formatRepository.GetAllAsync();

            MovieCreateDto createDto = new MovieCreateDto
            {
                Categories = categories,
                Cinemas = cinemas,
                Languages = languages,
                Formats = formats
    
            };
            return View(createDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateDto createDto)
        {
           
            try
            {
                if (!ModelState.IsValid) return View();
                await _movieService.CreateAsync(createDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(createDto);
            }

            

        }

        public IActionResult Update(int Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id,MovieUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                await _movieService.UpdateAsync(Id , updateDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(updateDto);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            await _movieService.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }

}

