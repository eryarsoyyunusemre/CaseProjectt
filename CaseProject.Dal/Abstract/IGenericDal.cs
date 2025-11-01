using System.Linq.Expressions;

namespace CaseProject.Dal.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task CreateAsync(T entity);
        
        Task UpdateAsync(T entity);
         
        Task DeleteAsync(string id);
        Task DeleteAsync(T entity);
        
        Task<List<T>> GetListAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);
        
        Task<T?> FindAsync(object id);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        
        IQueryable<T> GetIQueryable();
        
        Task<int> SaveAsync();
        
    }
}