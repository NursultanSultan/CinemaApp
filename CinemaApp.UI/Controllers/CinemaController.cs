﻿using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI.Controllers
{
    public class CinemaController : Controller
    {
        private AppDbContext _context { get; }
        public CinemaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int Id)
        {
            var cinema = _context.Cinemas.Where(c => c.Id == Id).FirstOrDefault();
            return View(cinema);
        }
    }
}
