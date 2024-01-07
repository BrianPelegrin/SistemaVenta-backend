using Microsoft.EntityFrameworkCore;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Domain.Common;
using SistemaVenta.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace SistemaVenta.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly InventoryDbContext _dbContext;

        public BaseRepository(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> Predicate)
        {
            return await _dbContext.Set<T>().Where(Predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> Predicate = null,
                                                        string IncludeProperty = null,
                                                        Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
                                                        bool DisableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (!DisableTracking)
            {
                query = query.AsNoTracking();
            }

            if(Predicate != null)
            {
                query = query.Where(Predicate);
            }

            if (!string.IsNullOrWhiteSpace(IncludeProperty))
            {
                query = query.Include(IncludeProperty);
            }

            if (OrderBy != null)
            {
                query = OrderBy(query);
            }


            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> Predicate = null,
                                                        List<Expression<Func<T, object>>> IncludesProperties = null,
                                                        Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
                                                        bool DisableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (!DisableTracking)
            {
                query = query.AsNoTracking();
            }

            if(Predicate!= null)
            {
                query = query.Where(Predicate);
            }

            if(IncludesProperties != null)
            {
                query = IncludesProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            if(OrderBy != null)
            {
                query = OrderBy(query);
            }

            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity; 
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
