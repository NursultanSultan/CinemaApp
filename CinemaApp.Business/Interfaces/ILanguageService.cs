using CinemaApp.Business.DTOs.LanguageDtos;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<LangReadDto>> GetAllAsync();
        Task<Language> GetAsync(int id);
        Task CreateAsync(LangCreateDto createDto);
        LangUpdateDto Update(int id);
        Task UpdateAsync(int id, LangUpdateDto updateDto);
        Task RemoveAsync(int id);
    }
}
