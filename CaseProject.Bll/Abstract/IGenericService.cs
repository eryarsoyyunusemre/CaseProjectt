using System.Linq.Expressions;
using CaseProject.Entities.IBase;

namespace CaseProject.Bll.Abstract;

public interface IGenericService<T> where T :class 
{
    IResponse<TDto> Find<TDto>(object id) where TDto : class, IDtoBase;
    IResponse<TDto> Get<TDto>(Expression<Func<T, bool>> expression) where TDto : class, IDtoBase;
    IResponse<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>>? expression = null) where TDto : class, IDtoBase;
    
    Task<IResponse<TDto>> Add<TDto>(TDto dto, bool saveChanges = true) 
        where TDto : class, IDtoBase;

    IResponse<TDto> Update<TDto>(int id, TDto dto) where TDto : class, IDtoBase;
    
    IResponse<bool> Delete(object id, bool saveChanges = true);
    
    IResponse<bool> Delete(Expression<Func<T, bool>> expression, bool saveChanges = true);
    
    IQueryable<T> GetIQueryable();
    
    Task<int> SaveAsync();
    
    Task<IResponse<TDto>> FindAsync<TDto>(object id) where TDto : class, IDtoBase;
    Task<IResponse<TDto>> GetAsync<TDto>(Expression<Func<T, bool>> expression) where TDto : class, IDtoBase;
    Task<IResponse<List<TDto>>> GetAllAsync<TDto>(Expression<Func<T, bool>>? expression = null) where TDto : class, IDtoBase;
}