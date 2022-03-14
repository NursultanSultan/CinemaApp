using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using CinemaApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.DataAcces.Implementations
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {

        private AppDbContext _context { get; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
