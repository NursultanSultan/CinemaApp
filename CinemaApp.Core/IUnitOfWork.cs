using CinemaApp.Core.Interfaces;
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


        public Task SavechangeAsync();
    }
}
