using CaseProject.Entities.IBase;
using CaseProject.Entities.Models;

namespace CaseProject.Bll.Abstract;

public interface IProductService : IGenericService<Product>
{
    Task<IResponse<TDto>> GetByBarcodeAsync<TDto>(string barcode) where TDto : class, IDtoBase;
}