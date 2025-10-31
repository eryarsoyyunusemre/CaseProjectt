using AutoMapper;
using CaseProject.Bll.Abstract;
using CaseProject.Dal.Abstract;
using CaseProject.Entities.Base;
using CaseProject.Entities.IBase;
using CaseProject.Entities.Models;

namespace CaseProject.Bll.Concrete;

public class ProductManager : GenericManager<Product>,IProductService
{
    
    private readonly IProductDal _productDal;

    public ProductManager(IGenericDal<Product> genericDal, IProductDal productDal, IMapper mapper)
        : base(genericDal, mapper)
    {
        _productDal = productDal;
    }

    public async Task<IResponse<TDto>> GetByBarcodeAsync<TDto>(string barcode) where TDto : class, IDtoBase
    {
        var product = await _productDal.GetAsync(p => p.Barcode == barcode);

        if (product == null)
        {
            return new Response<TDto>
            {
                Message = $"Product with barcode {barcode} not found.",
                StatusCode = 404,
                Data = null
            };
        }

        var dto = mapper.Map<TDto>(product);

        return new Response<TDto>
        {
            Message = "Product retrieved successfully.",
            StatusCode = 200,
            Data = dto
        };
    }

}