using AutoMapper;
using CinemaApp.Business.DTOs.CinemaDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task CreateAsync(CinemaCreateDto createDto)
        {
            Cinema cinema = new Cinema
            {
                CinemaName = createDto.CinemaName,
                EMail = createDto.EMail,
                ShortContent = createDto.ShortContent,
                MapLocation = createDto.MapLocation,
                OurAdress = createDto.OurAdress,
                PhoneNumber = createDto.PhoneNumber,
                WorkingHour = createDto.WorkingHour

            };

            string root = Path.Combine(_env.WebRootPath, "assets", "image");
            string FileName = await createDto.CinemaPosterPhoto.SaveFileAsync(root);
            cinema.CinemaPosterURL = FileName;

            /*File upload end*/

            await _unitOfWork.cinemaRepository.CreateAsync(cinema);
            await _unitOfWork.SavechangeAsync();
        }

        public async Task<IEnumerable<CinemaReadDto>> GetAllAsync()
        {
            var dbCinemas = await _unitOfWork.cinemaRepository
                                        .GetAllAsync(c => c.IsDeleted == false);

            //List<CategoryReadDto> readVM = _mapper.Map<List<CategoryReadDto>>(dbCategories);
            List<CinemaReadDto> cinemaDtos = new List<CinemaReadDto>();

            foreach (var cinema in dbCinemas)
            {
                CinemaReadDto readDto = new CinemaReadDto
                {
                   Id = cinema.Id,
                   CinemaName = cinema.CinemaName,
                   CinemaPosterURL = cinema.CinemaPosterURL,
                   EMail = cinema.EMail,
                   
                };

                cinemaDtos.Add(readDto);
            }

            return cinemaDtos;
        }

        public Task<Cinema> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var dbCategory = await _unitOfWork.cinemaRepository
                                        .GetAsync(c => c.Id == id);

            if (dbCategory == null)throw new NullReferenceException();

            dbCategory.IsDeleted = true;

            await _unitOfWork.SavechangeAsync();
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
