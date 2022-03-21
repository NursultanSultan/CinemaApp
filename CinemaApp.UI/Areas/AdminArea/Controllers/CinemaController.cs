using AutoMapper;
using CinemaApp.Business.DTOs.CinemaDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class CinemaController : Controller
    {
        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }
        private ICinemaService _cinemaService { get; }

        public CinemaController(IUnitOfWork unitOfWork, IMapper mapper
                , IWebHostEnvironment env, ICinemaService cinemaService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _cinemaService.GetAllAsync());
            
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaCreateDto createDto)
        { 

            //Category category = _mapper.Map<Category>(categoryCreateDto);

            /*File upload start*/
            try
            {
                if (!ModelState.IsValid) return View();
                await _cinemaService.CreateAsync(createDto);
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
        public async Task<IActionResult> Update(int Id, CinemaUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                if (Id != updateDto.Id) return BadRequest();

                await _cinemaService.UpdateAsync(Id, updateDto);
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
            
            await _cinemaService.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
