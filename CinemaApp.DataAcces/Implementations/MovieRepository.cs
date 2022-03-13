using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Implementations
{
    public class MovieRepository : Repository<Movie> , IMovieRepository
    {
        private AppDbContext _context { get; }

        public MovieRepository(AppDbContext context):base(context)
        {
            _context = context;
        }


    }
}
