using AutoMapper;
using CinemaApp.Business.Interfaces;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class NewsService : INewsService
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(News news)
        {
           
            await _unitOfWork.newsRepository.CreateAsync(news);
            await _unitOfWork.SavechangeAsync();
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {
            var dbNews = await _unitOfWork.newsRepository
                                        .GetAllAsync(c => c.IsDelete == false);

            return dbNews;
        }

        public Task<News> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var dbNews = await _unitOfWork.newsRepository.GetAsync(c => c.Id == id);
            if (dbNews == null) throw new NullReferenceException();

            dbNews.IsDelete = true;
            await _unitOfWork.SavechangeAsync();

        }

        public async Task UpdateAsync(int id, News news)
        {
            var dbNews = await _unitOfWork.newsRepository
                                        .GetAsync(c => c.Id == id);

            if (dbNews == null) throw new NullReferenceException();
            dbNews.Content = news.Content != null ? news.Content : dbNews.Content;
            await _unitOfWork.SavechangeAsync();
        }
    }
}
