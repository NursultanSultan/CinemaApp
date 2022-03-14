﻿using AutoMapper;
using CinemaApp.Business.DTOs;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class MovieController : Controller
    {
        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        public MovieController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.movieRepository.GetAllAsync(m => m.IsDeleted == false));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCreateDto createDto)
        {
            if (!ModelState.IsValid) return View();

            Movie movie = _mapper.Map<Movie>(createDto);

            /*File upload start*/
            //if (!createVM.Photo.CheckFileType("image/"))
            //{
            //    ModelState.AddModelError("Photo", "File must be image type");
            //    return View(createVM);
            //}

            //if (!createVM.Photo.CheckFileSize(300))
            //{
            //    ModelState.AddModelError("Photo", "File must be less than 300kb");
            //    return View(createVM);
            //}

            //string root = Path.Combine(_env.WebRootPath, "assets", "image");
            //string FileName = await createVM.Photo.SaveFileAsync(root);
            //doctor.Image = FileName;

            /*File upload end*/

            //await _context.Doctors.AddAsync(doctor);
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update()
        {

            //if (!ModelState.IsValid) return View();

            //if (Id != updateVM.Id) return BadRequest();
            //var dbDoctor = await _context.Doctors.FindAsync(Id);
            //if (dbDoctor == null) return NotFound();

            //if (updateVM.Photo != null)
            //{
            //    /*File upload start*/
            //    if (!updateVM.Photo.CheckFileType("image/"))
            //    {
            //        ModelState.AddModelError("Photo", "File must be image type");
            //        return View(updateVM);
            //    }

            //    if (!updateVM.Photo.CheckFileSize(300))
            //    {
            //        ModelState.AddModelError("Photo", "File must be less than 300kb");
            //        return View(updateVM);
            //    }


            //    string root = Path.Combine(_env.WebRootPath, "assets", "image");
            //    string FileName = dbDoctor.Image;
            //    string resultPath = Path.Combine(root, FileName);

            //    if (System.IO.File.Exists(resultPath))
            //    {
            //        System.IO.File.Delete(resultPath);
            //    }

            //    string UpdatedFileName = await updateVM.Photo.SaveFileAsync(root);
            //    dbDoctor.Image = UpdatedFileName;

            //    /*File upload end*/
            //}

            //dbDoctor.Name = updateVM.Name != null ? updateVM.Name : dbDoctor.Name;
            //dbDoctor.Work = updateVM.Work != null ? updateVM.Work : dbDoctor.Work;




            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            //var dbDoctor = await _context.Doctors.FindAsync(Id);
            //if (dbDoctor == null) return NotFound();

            //dbDoctor.IsDeleted = true;

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
