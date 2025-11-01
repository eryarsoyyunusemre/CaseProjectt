using CaseProject.Bll.Abstract;
using CaseProject.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _companyService.GetAllAsync<DtoCompany>();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _companyService.FindAsync<DtoCompany>(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DtoCompany dtoCompany)
        {
            try
            {
                var response = await _companyService.Add(dtoCompany);

                return StatusCode(response.StatusCode, response);
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
        public async Task<IActionResult> Update(int id, [FromBody] DtoCompanyUpdate dtoCompany)
        {
            dtoCompany.Id = id;
            var response = await _companyService.Update(dtoCompany);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _companyService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}