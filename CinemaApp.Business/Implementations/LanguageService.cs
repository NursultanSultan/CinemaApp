using AutoMapper;
using CinemaApp.Business.DTOs.LanguageDtos;
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
    public class LanguageService : ILanguageService
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }

        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(LangCreateDto createDto)
        {
            Language language = new Language
            {
                Lang = createDto.Lang

            };

            if (!createDto.LangIconFile.CheckFileType("image/"))
            {
                throw new FileTypeException("File must be image type");
            }
            if (!createDto.LangIconFile.CheckFileSize(300))
            {
                throw new FileTypeException("File must be less than 300kb");
            }

            string root = Path.Combine(_env.WebRootPath, "assets", "image");
            string FileName = await createDto.LangIconFile.SaveFileAsync(root);
            language.LangIconUrl = FileName;

            /*File upload end*/

            await _unitOfWork.languageRepository.CreateAsync(language);
            await _unitOfWork.SavechangeAsync();
        }

        public async Task<IEnumerable<LangReadDto>> GetAllAsync()
        {
            var dbLanguages = await _unitOfWork.languageRepository
                                        .GetAllAsync(c => c.IsDeleted == false);

            //List<CategoryReadDto> readVM = _mapper.Map<List<CategoryReadDto>>(dbCategories);
            List<LangReadDto> languageDtos = new List<LangReadDto>();

            foreach (var language in dbLanguages)
            {
                LangReadDto readDto = new LangReadDto
                {
                    Id = language.Id,
                    Lang = language.Lang,
                    LangIconUrl = language.LangIconUrl
                };

                languageDtos.Add(readDto);
            }

            return languageDtos;
        }

        public Task<Language> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            var dbLanguage = await _unitOfWork.languageRepository
                                        .GetAsync(c => c.Id == id);

            if (dbLanguage == null) throw new NullReferenceException();

            dbLanguage.IsDeleted = true;

            await _unitOfWork.SavechangeAsync();
        }

        public LangUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, LangUpdateDto updateDto)
        {
            var dbLanguage = await _unitOfWork.languageRepository
                                        .GetAsync(c => c.Id == id);

            if (dbLanguage == null) throw new NullReferenceException();

            if (updateDto.LangIconFile != null)
            {
                /*File upload start*/
                if (!updateDto.LangIconFile.CheckFileType("image/"))
                {
                    throw new FileTypeException("File must be image type");
                }
                if (!updateDto.LangIconFile.CheckFileSize(300))
                {
                    throw new FileTypeException("File must be less than 300kb");
                }


                string root = Path.Combine(_env.WebRootPath, "assets", "image");
                string FileName = dbLanguage.LangIconUrl;
                string resultPath = Path.Combine(root, FileName);

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                string UpdatedFileName = await updateDto.LangIconFile.SaveFileAsync(root);
                dbLanguage.LangIconUrl = UpdatedFileName;

                /*File upload end*/
            }

            dbLanguage.Lang = updateDto.Lang != null ? updateDto.Lang : dbLanguage.Lang;


            await _unitOfWork.SavechangeAsync();
        }
    }
}
