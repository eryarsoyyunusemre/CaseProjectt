using CaseProject.Bll.Abstract;
using CaseProject.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync<DtoProduct>();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.FindAsync<DtoProduct>(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            var response = await _productService.GetByBarcodeAsync<DtoProduct>(barcode);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DtoProduct dtoProduct)
        {
            try
            {
                var response = await _productService.Add(dtoProduct);

                if (response.StatusCode == 201)
                    return Ok(response.Data);

                return StatusCode(response.StatusCode, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "An error occurred while creating the company.",
                    Details = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DtoProductUpdate dto)
        {
            dto.Id = id;
            var response = await _productService.Update(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}