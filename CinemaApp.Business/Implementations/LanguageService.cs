﻿using CinemaApp.Business.DTOs.LanguageDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class LanguageService : ILanguageService
    {
        public Task CreateAsync(LangCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LangReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
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