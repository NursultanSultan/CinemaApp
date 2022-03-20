using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAllAsync();
        Task<News> GetAsync(int id);
        Task CreateAsync(News news);
        Task UpdateAsync(int id, News news);
        Task RemoveAsync(int id);
    }
}
