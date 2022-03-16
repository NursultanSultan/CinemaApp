using AutoMapper;
using CinemaApp.Business.DTOs.LanguageDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
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
            if (!ModelState.IsValid) return View();

            //Category category = _mapper.Map<Category>(categoryCreateDto);

            /*File upload start*/
            if (!createDto.LangIconFile.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File must be image type");
                return View(createDto);
            }

            if (!createDto.LangIconFile.CheckFileSize(300))
            {
                ModelState.AddModelError("Photo", "File must be less than 300kb");
                return View(createDto);
            }

            await _languageService.CreateAsync(createDto);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, LangUpdateDto updateDto)
        {

            if (!ModelState.IsValid) return View();

            if (Id != updateDto.Id) return BadRequest();
            var dbLanguage = await _unitOfWork.languageRepository
                                        .GetAsync(c => c.Id == Id);

            if (dbLanguage == null) return NotFound();

            if (updateDto.LangIconFile != null)
            {
                /*File upload start*/
                if (!updateDto.LangIconFile.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File must be image type");
                    return View(updateDto);
                }

                if (!updateDto.LangIconFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("Photo", "File must be less than 300kb");
                    return View(updateDto);
                }


                string root = Path.Combine(_env.WebRootPath, "assets", "image");
                string FileName = dbLanguage.LangIconUrl;
                string resultPath = Path.Combine(root, FileName);

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                string UpdatedFileName = await updateDto.LangIconFile.SaveFileAsync(root);
                dbLanguage.LangIconUrl = UpdatedFileName;

                /*File upload end*/
            }

            dbLanguage.Lang = updateDto.Lang != null ? updateDto.Lang : dbLanguage.Lang;


            await _unitOfWork.SavechangeAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            //var dbCategory = await _unitOfWork.categoryRepository
            //                            .GetAsync(c => c.Id == Id);

            //if (dbCategory == null) return NotFound();

            //dbCategory.IsDeleted = true;

            //await _unitOfWork.SavechangeAsync();

            await _languageService.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
