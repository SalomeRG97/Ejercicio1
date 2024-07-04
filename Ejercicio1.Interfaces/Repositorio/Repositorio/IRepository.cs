using System.Linq.Expressions;

namespace Ejercicio1.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void AddAsync<TDto>(TDto dto);
        Task AddRange<TDto>(IEnumerable<TDto> dtos);
        void DeleteAsync<TDto>(TDto dto);
        Task<List<TDto>> GetAllAsync<TDto>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null, bool disableTracking = true);
        Task<TDto?> GetAsync<TDto>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true);
        void UpdateAsync<TDto>(TDto dto);
    }
}