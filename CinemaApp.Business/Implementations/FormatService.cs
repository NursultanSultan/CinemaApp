using CinemaApp.Business.DTOs.FormatDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class FormatService : IFormatService
    {
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
