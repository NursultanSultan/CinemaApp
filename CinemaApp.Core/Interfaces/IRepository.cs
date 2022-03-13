using CinemaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp = null);

        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> isExistExp, Expression<Func<TEntity, bool>> descendingExp);
        


        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
