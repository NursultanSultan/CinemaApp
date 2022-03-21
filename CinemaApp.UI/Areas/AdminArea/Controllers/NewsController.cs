using AutoMapper;
using CinemaApp.Business.Interfaces;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        
        private INewsService _newsService { get; }

        public NewsController(IUnitOfWork unitOfWork, IMapper mapper
                , INewsService newsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _newsService = newsService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _newsService.GetAllAsync());
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {

            //Category category = _mapper.Map<Category>(categoryCreateDto);

            /*File upload start*/
            try
            {
                if (!ModelState.IsValid) return View();
                await _newsService.CreateAsync(news);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(news);
            }

        }

        public IActionResult Update(int Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, News news)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                if (Id != news.Id) return BadRequest();

                await _newsService.UpdateAsync(Id, news);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(news);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {

            await _newsService.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
