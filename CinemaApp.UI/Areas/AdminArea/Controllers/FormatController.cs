using AutoMapper;
using CinemaApp.Business.DTOs.FormatDtos;
using CinemaApp.Business.Interfaces;
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
    public class FormatController : Controller
    {
        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }
        private IFormatService _formatService { get; }

        public FormatController(IUnitOfWork unitOfWork, IMapper mapper
                , IWebHostEnvironment env, IFormatService formatService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _formatService = formatService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _formatService.GetAllAsync());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormatCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                await _formatService.CreateAsync(createDto);
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
        public async Task<IActionResult> Update(int Id, FormatUpdateDto updateDto)
        {

            try
            {
                if (!ModelState.IsValid) return View();
                if (Id != updateDto.Id) return BadRequest();

                await _formatService.UpdateAsync(Id, updateDto);
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

            await _formatService.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }


    }
}
