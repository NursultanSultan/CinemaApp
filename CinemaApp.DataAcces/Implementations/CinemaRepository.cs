using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Implementations
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {

        private AppDbContext _context { get; }

        public CinemaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
