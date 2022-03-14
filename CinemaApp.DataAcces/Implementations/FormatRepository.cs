using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Implementations
{
    public class FormatRepository : Repository<Format>, IFormatRepository
    {
        private AppDbContext _context { get; }

        public FormatRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
