using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Implementations
{
    public class MovieCinemaRepository : Repository<MovieCinema>, IMovieCinemaRepository
    {
        private AppDbContext _context { get; }

        public MovieCinemaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
