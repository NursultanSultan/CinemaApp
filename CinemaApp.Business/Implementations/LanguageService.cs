using AutoMapper;
using CinemaApp.Business.DTOs.LanguageDtos;
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

        public Task CreateAsync(LangCreateDto createDto)
        {
            throw new NotImplementedException();
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

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public LangUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, LangUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
