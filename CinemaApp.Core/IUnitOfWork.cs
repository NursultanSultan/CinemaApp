using CinemaApp.Core.Interfaces;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core
{
    public interface IUnitOfWork
    {
        public IMovieRepository movieRepository { get;}

        public ICategoryRepository categoryRepository { get; }

        public ICinemaRepository cinemaRepository { get; }

        public ILanguageRepository languageRepository { get; }

        public IFormatRepository formatRepository { get; }

        public INewsRepository newsRepository { get; }

        public IMovieCategoryRepository movieCategoryRepository { get;}

        public IMovieCinemaRepository movieCinemaRepository { get;}

        public IMovieLanguageRepository movieLanguageRepository { get;}

        public IMovieFormatRepository movieFormatRepository { get;}

        public IContactUsRepository contactUsRepository { get;}

        


        public Task SavechangeAsync();
    }
}
