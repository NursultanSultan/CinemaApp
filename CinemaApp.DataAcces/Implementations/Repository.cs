using CinemaApp.Core.Entities;
using CinemaApp.Core.Interfaces;
using CinemaApp.DataAcces.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DataAcces.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private AppDbContext _context { get; }

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = GetQuery(includes);
            return exp is null
                ? await query.ToListAsync()
                : await query.Where(exp).ToListAsync();
        }

        
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {
            var query = GetQuery(includes);
            return exp is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(exp).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp = null)
        {
            return await _context.Set<TEntity>().AnyAsync(exp);
        }

        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> isExistExp, Expression<Func<TEntity, bool>> descendingExp)
        {
            var query = GetQuery();

            return query.Where(isExistExp).OrderByDescending(descendingExp);
        }

        

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

        }

        private IQueryable<TEntity> GetQuery(params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

      
    }
}
