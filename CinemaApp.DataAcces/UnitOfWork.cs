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
        private INewsRepository _newsRepository;
        private IMovieCategoryRepository _movieCategoryRepository;
        private IMovieCinemaRepository _movieCinemaRepository;
        private IMovieLanguageRepository _movieLanguageRepository;
        private IMovieFormatRepository _movieFormatRepository;
        private IContactUsRepository _contactUsRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        


        public IMovieRepository movieRepository => _movieRepository = _movieRepository ?? new MovieRepository(_context);
        public ICategoryRepository categoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public ICinemaRepository cinemaRepository => _cinemaRepository = _cinemaRepository ?? new CinemaRepository(_context);
        public ILanguageRepository languageRepository => _languageRepository = _languageRepository ?? new LanguageRepository(_context);
        public IFormatRepository formatRepository => _formatRepository = _formatRepository ?? new FormatRepository(_context);
        public INewsRepository newsRepository => _newsRepository = _newsRepository ?? new NewsRepository(_context);
        public IMovieCategoryRepository movieCategoryRepository => _movieCategoryRepository = _movieCategoryRepository ?? new MovieCategoryRepository(_context);
        public IMovieCinemaRepository movieCinemaRepository => _movieCinemaRepository = _movieCinemaRepository ?? new MovieCinemaRepository(_context);
        public IMovieLanguageRepository movieLanguageRepository => _movieLanguageRepository = _movieLanguageRepository ?? new MovielanguageRepository(_context);
        public IMovieFormatRepository movieFormatRepository => _movieFormatRepository = _movieFormatRepository ?? new MovieFormatRepository(_context);
        public IContactUsRepository contactUsRepository => _contactUsRepository = _contactUsRepository ?? new ContactUsRepository(_context);



        public async Task SavechangeAsync()
        {
           await _context.SaveChangesAsync();
        }
        
    }
}
