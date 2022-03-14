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
        private ICinemaRepository _cinemaRepository;
        private ILanguageRepository _languageRepository;
        private IFormatRepository _formatRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        


        public IMovieRepository movieRepository => _movieRepository = _movieRepository ?? new MovieRepository(_context);
        public ICategoryRepository categoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public ICinemaRepository cinemaRepository => _cinemaRepository = _cinemaRepository ?? new CinemaRepository(_context);
        public ILanguageRepository languageRepository => _languageRepository = _languageRepository ?? new LanguageRepository(_context);
        public IFormatRepository formatRepository => _formatRepository = _formatRepository ?? new FormatRepository(_context);


        public async Task SavechangeAsync()
        {
           await _context.SaveChangesAsync();
        }
        
    }
}
