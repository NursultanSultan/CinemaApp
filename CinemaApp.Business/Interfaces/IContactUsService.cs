using CinemaApp.Business.DTOs;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Interfaces
{
    public interface IContactUsService
    {
        Task<IEnumerable<ContactUs>> GetAllAsync();

        Task CreateAsync(ContactUsCreateDto contactUsDto);

        Task RemoveAsync(int id);
    }
}
