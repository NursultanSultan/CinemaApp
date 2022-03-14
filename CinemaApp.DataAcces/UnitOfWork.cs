using CinemaApp.Core;
using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using CinemaApp.DataAcces.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DataAcces
{
    public class UnitOfWork : IUnitOfWork
    {

        private AppDbContext _context { get; }
        private IMovieRepository _movieRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        


        public IMovieRepository movieRepository => _movieRepository = _movieRepository ?? new MovieRepository(_context);
        public ICategoryRepository categoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);


        public async Task SavechangeAsync()
        {
           await _context.SaveChangesAsync();
        }
        
    }
}
