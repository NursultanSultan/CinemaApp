using AutoMapper;
using CinemaApp.Business.DTOs.CategoryDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
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
    public class CategoryController : Controller
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }
        private ICategoryService _categoryService { get; } 

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper 
                , IWebHostEnvironment env , ICategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllAsync());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {

            //Category category = _mapper.Map<Category>(categoryCreateDto);

            /*File upload start*/
            try
            {
                if (!ModelState.IsValid) return View();
                await _categoryService.CreateAsync(categoryCreateDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty,ex.Message.ToString());
                return View(categoryCreateDto);
            }

        }

        public IActionResult Update(int Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                if (Id != categoryUpdateDto.Id) return BadRequest();

                await _categoryService.UpdateAsync(Id, categoryUpdateDto); 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(categoryUpdateDto);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {

            await _categoryService.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
