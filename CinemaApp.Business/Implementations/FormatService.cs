using AutoMapper;
using CinemaApp.Business.DTOs.FormatDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class FormatService : IFormatService
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }

        public FormatService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public Task CreateAsync(FormatCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FormatReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Format> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public FormatUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, FormatUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
