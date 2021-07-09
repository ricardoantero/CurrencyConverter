using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlDbContext Context;
        protected readonly DbSet<TEntity> Entities;

        public BaseRepository(SqlDbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public virtual async Task Delete(int id)
        {
            var entity = await Entities.SingleOrDefaultAsync(e => e.Id == id);

            entity.Active = false;
            Context.Entry(entity).State = EntityState.Modified;

            await Context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
            {
                return await Entities.ToListAsync();
            }

            return await Entities.Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual async Task Add(TEntity entity)
        {
            await Entities.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual Task Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}
