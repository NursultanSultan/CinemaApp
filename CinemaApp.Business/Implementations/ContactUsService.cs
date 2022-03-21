using CinemaApp.Business.DTOs;
using CinemaApp.Business.Interfaces;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class ContactUsService : IContactUsService
    {
        private IUnitOfWork _unitOfWork { get; }
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }


        public ContactUsService(IUnitOfWork unitOfWork , UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<ContactUs>> GetAllAsync()
        {
            var dbContactUs = await _unitOfWork.contactUsRepository.GetAllAsync();

            return dbContactUs;
        }

        public async Task CreateAsync(ContactUsCreateDto contactUsDto)
        {
            ContactUs contactUs = new ContactUs
            {
                UserMail = contactUsDto.UserMail,
                Message = contactUsDto.Message,
                Subject = contactUsDto.Subject
            };


            await _unitOfWork.contactUsRepository.CreateAsync(contactUs);
            await _unitOfWork.SavechangeAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var dbContactUs = await _unitOfWork.contactUsRepository.GetAsync(d => d.Id == id);
            if (dbContactUs is null) throw new NullReferenceException();

            _unitOfWork.contactUsRepository.Remove(dbContactUs);
            await _unitOfWork.SavechangeAsync();
        }
    }
}
