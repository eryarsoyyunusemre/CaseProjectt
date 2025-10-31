using System.Linq.Expressions;
using AutoMapper;
using CaseProject.Bll.Abstract;
using CaseProject.Dal.Abstract;
using CaseProject.Entities.Base;
using CaseProject.Entities.IBase;

namespace CaseProject.Bll.Concrete;

public class GenericManager<T> : IGenericService<T> where T : class
{
    private readonly IGenericDal<T> _genericDal;
    protected readonly IMapper mapper;

    public GenericManager(IGenericDal<T> genericDal, IMapper mapper)
    {
        _genericDal = genericDal;
        this.mapper = mapper;
    }


    public IResponse<TDto> Find<TDto>(object id) where TDto : class, IDtoBase
    {
        var entity = _genericDal.FindAsync(id).GetAwaiter().GetResult();
        if (entity == null)
            return new Response<TDto>
            {
                Message = $"Entity with ID {id} not found.",
                StatusCode = 404,
                Data = null
            };

        var dto = mapper.Map<TDto>(entity);
        return new Response<TDto>
        {
            Message = "Success",
            StatusCode = 200,
            Data = dto
        };
    }

    public IResponse<TDto> Get<TDto>(Expression<Func<T, bool>> expression) where TDto : class, IDtoBase
    {
        var entity = _genericDal.GetAsync(expression).GetAwaiter().GetResult();
        if (entity == null)
            return new Response<TDto>
            {
                Message = "Entity not found.",
                StatusCode = 404,
                Data = null
            };

        var dto = mapper.Map<TDto>(entity);
        return new Response<TDto>
        {
            Message = "Success",
            StatusCode = 200,
            Data = dto
        };
    }

    public IResponse<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>>? expression = null) where TDto : class, IDtoBase
    {
        var entities = _genericDal.GetAllAsync(expression).GetAwaiter().GetResult();
        var dtoList = mapper.Map<List<TDto>>(entities);

        return new Response<List<TDto>>
        {
            Message = "Success",
            StatusCode = 200,
            Data = dtoList
        };
    }

    public async Task<IResponse<TDto>> Add<TDto>(TDto dto, bool saveChanges = true)
        where TDto : class, IDtoBase
    {
        var entity = mapper.Map<T>(dto);

        await _genericDal.CreateAsync(entity);

        return new Response<TDto>
        {
            Message = "Success",
            StatusCode = 201,
            Data = dto
        };
    }

    public IResponse<TDto> Update<TDto>(int id, TDto dto) where TDto : class, IDtoBase
    {
        var idProperty = dto.GetType().GetProperty("Id");
        if (idProperty != null)
        {
            idProperty.SetValue(dto, id);
        }

        var entity = mapper.Map<T>(dto);

        _genericDal.UpdateAsync(entity).GetAwaiter().GetResult();

        return new Response<TDto>
        {
            Message = "Update Success",
            StatusCode = 200,
            Data = dto
        };
    }


    public IResponse<bool> Delete(object id, bool saveChanges = true)
    {
        var entity = _genericDal.FindAsync(id).GetAwaiter().GetResult();
        if (entity == null)
        {
            return new Response<bool>
            {
                Message = "Entity not found",
                StatusCode = 404,
                Data = false
            };
        }

        _genericDal.DeleteAsync(entity).GetAwaiter().GetResult();

        return new Response<bool>
        {
            Message = "Delete Success",
            StatusCode = 200,
            Data = true
        };
    }

    public IResponse<bool> Delete(Expression<Func<T, bool>> expression, bool saveChanges = true)
    {
        var entity = _genericDal.GetAllAsync(expression).GetAwaiter().GetResult().FirstOrDefault();
        if (entity == null)
        {
            return new Response<bool>
            {
                Message = "Entity not found",
                StatusCode = 404,
                Data = false
            };
        }

        _genericDal.DeleteAsync(entity).GetAwaiter().GetResult();

        return new Response<bool>
        {
            Message = "Delete Success",
            StatusCode = 200,
            Data = true
        };
    }

    public IQueryable<T> GetIQueryable()
    {
        return _genericDal.GetIQueryable();
    }

    public async Task<int> SaveAsync()
    {
        return await _genericDal.SaveAsync();
    }

    public async Task<IResponse<TDto>> FindAsync<TDto>(object id) where TDto : class, IDtoBase
    {
        var entity = await _genericDal.FindAsync(id);
        if (entity == null)
            return new Response<TDto>
            {
                Message = "Entity not found",
                StatusCode = 404,
                Data = null
            };

        var dto = mapper.Map<TDto>(entity);
        return new Response<TDto>
        {
            Message = "Success",
            StatusCode = 200,
            Data = dto
        };
    }

    public async Task<IResponse<TDto>> GetAsync<TDto>(Expression<Func<T, bool>> expression) where TDto : class, IDtoBase
    {
        var entity = await _genericDal.GetAsync(expression);
        if (entity == null)
            return new Response<TDto>
            {
                Message = "Entity not found",
                StatusCode = 404,
                Data = null
            };

        var dto = mapper.Map<TDto>(entity);
        return new Response<TDto>
        {
            Message = "Success",
            StatusCode = 200,
            Data = dto
        };
    }

    public async Task<IResponse<List<TDto>>> GetAllAsync<TDto>(Expression<Func<T, bool>>? expression = null)
        where TDto : class, IDtoBase
    {
        var list = await _genericDal.GetAllAsync(expression);
        var dtoList = mapper.Map<List<TDto>>(list);

        return new Response<List<TDto>>
        {
            Message = "Success",
            StatusCode = 200,
            Data = dtoList
        };
    }
}