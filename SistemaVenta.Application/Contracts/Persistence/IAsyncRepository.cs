using System.Linq.Expressions;

namespace SistemaVenta.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T,bool>> Predicate);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T,bool>> Predicate = null,
                                           string IncludeProperty = null,
                                           Func<IQueryable<T>,IOrderedQueryable<T>> OrderBy = null,
                                           bool DisableTracking = true);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T,bool>> Predicate = null,
                                           List<Expression<Func<T,object>>> IncludesProperties = null,
                                           Func<IQueryable<T>,IOrderedQueryable<T>> OrderBy = null,
                                           bool DisableTracking = true);

        Task<T> GetByIdAsync(int id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> Predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> Predicate);
        Task<int> CountAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        
    }
}
