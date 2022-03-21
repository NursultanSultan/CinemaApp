using CinemaApp.Business.DTOs;
using CinemaApp.Business.Interfaces;
using CinemaApp.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class ContactUsController : Controller
    {
        private IContactUsService _contactUsService { get; }
        private IUnitOfWork _unitOfWork { get; }

        public ContactUsController(IContactUsService contactUsService, IUnitOfWork unitOfWork)
        {
            _contactUsService = contactUsService;
            _unitOfWork = unitOfWork;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactUsCreateDto contactUsCreateDto)
        {
            try
            {

                if (!ModelState.IsValid) return View(contactUsCreateDto);

                await _contactUsService.CreateAsync(contactUsCreateDto);

                return RedirectToAction(nameof(Create));

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message.ToString());
                return View(contactUsCreateDto);
            }

        }


    }
}
