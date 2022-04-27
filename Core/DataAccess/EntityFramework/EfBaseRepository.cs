using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (TContext context = new())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (TContext context = new())
            {
                var deletedEntity = await context.Set<TEntity>().FindAsync(id);
                await Task.Run(() => { context.Set<TEntity>().Remove(deletedEntity); });
                var data = await context.SaveChangesAsync();
                return data > 0 ? true : false;
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (TContext context = new())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (TContext context = new())
            {
                await Task.Run(() => { context.Set<TEntity>().Update(entity); });
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}