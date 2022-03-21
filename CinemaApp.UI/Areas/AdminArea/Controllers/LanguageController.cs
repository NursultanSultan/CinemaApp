using AutoMapper;
using CinemaApp.Business.DTOs.LanguageDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }
        private ILanguageService _languageService { get; }

        public LanguageController(IUnitOfWork unitOfWork, IMapper mapper
                , IWebHostEnvironment env, ILanguageService languageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _languageService.GetAllAsync());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LangCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                await _languageService.CreateAsync(createDto);
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
        public async Task<IActionResult> Update(int Id, LangUpdateDto updateDto)
        {

            try
            {
                if (!ModelState.IsValid) return View();
                if (Id != updateDto.Id) return BadRequest();

                await _languageService.UpdateAsync(Id, updateDto);
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
            
            await _languageService.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
