using System.Linq.Expressions;
using CaseProject.Dal.Abstract;
using CaseProject.Dal.Context;
using Microsoft.EntityFrameworkCore;

namespace CaseProject.Dal.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CaseProjectContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(CaseProjectContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"No record found for ID: {id}");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
        {
            if (expression != null)
            {
                return await _dbSet.Where(expression).ToListAsync();
            }
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> FindAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetIQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
