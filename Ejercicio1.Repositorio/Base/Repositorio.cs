using System.Linq.Expressions;
using AutoMapper;
using Ejercicio1.Entidades;
using Microsoft.EntityFrameworkCore;
using Ejercicio1.Interfaces;

namespace Ejercicio1.Repositorio
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EjerciciosContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public Repository(EjerciciosContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public void AddAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _dbSet.Add(entity);
        }

        public async Task AddRange<TDto>(IEnumerable<TDto> dtos)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtos);
            await _dbSet.AddRangeAsync(entities);
        }

        public void DeleteAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public async Task<List<TDto>> GetAllAsync<TDto>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeString = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return _mapper.Map<List<TDto>>(await orderBy(query).ToListAsync());
            return _mapper.Map<List<TDto>>(await query.ToListAsync());
        }

        public async Task<TDto?> GetAsync<TDto>(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return _mapper.Map<TDto>(await orderBy(query).FirstOrDefaultAsync());
            return _mapper.Map<TDto>(await query.FirstOrDefaultAsync());
        }

        public void UpdateAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
