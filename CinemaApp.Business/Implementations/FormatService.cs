using AutoMapper;
using CinemaApp.Business.DTOs.FormatDtos;
using CinemaApp.Business.Exceptions.FileExceptions;
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

        public async Task CreateAsync(FormatCreateDto createDto)
        {
            Format format = new Format
            {
                FormatType = createDto.FormatType
            };
            if (!createDto.FormatIconFile.CheckFileType("image/"))
            {
                throw new FileTypeException("File must be image type");
            }
            if (!createDto.FormatIconFile.CheckFileSize(300))
            {
                throw new FileTypeException("File must be less than 300kb");
            }

            string root = Path.Combine(_env.WebRootPath, "assets", "image");
            string FileName = await createDto.FormatIconFile.SaveFileAsync(root);
            format.FormatIconUrl = FileName;

            /*File upload end*/

            await _unitOfWork.formatRepository.CreateAsync(format);
            await _unitOfWork.SavechangeAsync();
        }

        public async Task<IEnumerable<FormatReadDto>> GetAllAsync()
        {
            var dbFormats = await _unitOfWork.formatRepository
                                        .GetAllAsync(c => c.IsDeleted == false);

            //List<CategoryReadDto> readVM = _mapper.Map<List<CategoryReadDto>>(dbCategories);
            List<FormatReadDto> formatDtos = new List<FormatReadDto>();

            foreach (var format in dbFormats)
            {
                FormatReadDto readDto = new FormatReadDto
                {
                    Id = format.Id,
                    FormatType = format.FormatType,
                    FormatIconUrl = format.FormatIconUrl
                };

                formatDtos.Add(readDto);
            }

            return formatDtos;
        }

        public Task<Format> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var dbFormat = await _unitOfWork.formatRepository
                                        .GetAsync(c => c.Id == id);

            if (dbFormat == null) throw new NullReferenceException();

            dbFormat.IsDeleted = true;

            await _unitOfWork.SavechangeAsync();
        }

        public FormatUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, FormatUpdateDto updateDto)
        {
            var dbFormat = await _unitOfWork.formatRepository
                                        .GetAsync(c => c.Id == id);

            if (dbFormat == null) throw new NullReferenceException();

            if (updateDto.FormatIconFile != null)
            {
                /*File upload start*/
                if (!updateDto.FormatIconFile.CheckFileType("image/"))
                {
                    throw new FileTypeException("File must be image type");
                }
                if (!updateDto.FormatIconFile.CheckFileSize(300))
                {
                    throw new FileTypeException("File must be less than 300kb");
                }


                string root = Path.Combine(_env.WebRootPath, "assets", "image");
                string FileName = dbFormat.FormatIconUrl;
                string resultPath = Path.Combine(root, FileName);

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                string UpdatedFileName = await updateDto.FormatIconFile.SaveFileAsync(root);
                dbFormat.FormatIconUrl = UpdatedFileName;

                /*File upload end*/
            }

            dbFormat.FormatType = updateDto
                                      .FormatType != null ? updateDto.FormatType : dbFormat.FormatType;


            await _unitOfWork.SavechangeAsync();
        }
    }
}
