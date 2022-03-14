using AutoMapper;
using CinemaApp.Business.DTOs.CategoryDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
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
            if (!ModelState.IsValid) return View();

            //Category category = _mapper.Map<Category>(categoryCreateDto);

            /*File upload start*/
            if (!categoryCreateDto.CategoryPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File must be image type");
                return View(categoryCreateDto);
            }

            if (!categoryCreateDto.CategoryPhoto.CheckFileSize(300))
            {
                ModelState.AddModelError("Photo", "File must be less than 300kb");
                return View(categoryCreateDto);
            }

            await _categoryService.CreateAsync(categoryCreateDto);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, CategoryUpdateDto categoryUpdateDto)
        {

            if (!ModelState.IsValid) return View();

            if (Id != categoryUpdateDto.Id) return BadRequest();
            var dbCategory = await _unitOfWork.categoryRepository
                                        .GetAsync(c => c.Id == Id);

            if (dbCategory == null) return NotFound();

            if (categoryUpdateDto.CategoryPhoto != null)
            {
                /*File upload start*/
                if (!categoryUpdateDto.CategoryPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File must be image type");
                    return View(categoryUpdateDto);
                }

                if (!categoryUpdateDto.CategoryPhoto.CheckFileSize(300))
                {
                    ModelState.AddModelError("Photo", "File must be less than 300kb");
                    return View(categoryUpdateDto);
                }


                string root = Path.Combine(_env.WebRootPath, "assets", "image");
                string FileName = dbCategory.CategoryImageURL;
                string resultPath = Path.Combine(root, FileName);

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                string UpdatedFileName = await categoryUpdateDto.CategoryPhoto.SaveFileAsync(root);
                dbCategory.CategoryImageURL = UpdatedFileName;

                /*File upload end*/
            }

            dbCategory.CategoryName = categoryUpdateDto
                                      .CategoryName != null ? categoryUpdateDto.CategoryName : dbCategory.CategoryName;


            

            await _unitOfWork.SavechangeAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            var dbCategory = await _unitOfWork.categoryRepository
                                        .GetAsync(c => c.Id == Id);

            if (dbCategory == null) return NotFound();

            dbCategory.IsDeleted = true;

            await _unitOfWork.SavechangeAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
