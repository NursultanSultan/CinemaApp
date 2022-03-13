using CinemaApp.Core;
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
        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
           
            return View(_unitOfWork.movieRepository.GetAllAsync(m => m.IsDeleted == false));
        }

        public IActionResult Create()
        {

            return View();
        }

        
    }

}

