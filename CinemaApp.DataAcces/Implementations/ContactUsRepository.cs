using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Implementations
{
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        private AppDbContext _context { get; set; }
        public ContactUsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
