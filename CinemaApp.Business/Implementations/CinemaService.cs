using AutoMapper;
using CinemaApp.Business.DTOs.CinemaDtos;
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
    public class CinemaService : ICinemaService
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }

        public CinemaService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public Task CreateAsync(CinemaCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CinemaReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cinema> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public CinemaUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, CinemaUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
