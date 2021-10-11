using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Application.CompanyApp;

namespace Pharmacy.API.Controllers
{
    [Route("api/v1/firmalar")]
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
            var result = await _companyService.GetAll();
            return Ok(new { status = true, data = result, errors = "" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _companyService.GetById(id);
            return Ok(new { status = true, data = result, errors = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CompanyDto companyDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _companyService.Add(companyDto);
            
            return Ok(new { status = true, errors = "" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _companyService.Delete(id);
            return Ok(new { status = true, errors = "" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CompanyDto companyDto)
        {
            companyDto.CompanyId = id;
            _companyService.Update(companyDto);
            return Ok(new { status = true, errors = "" });
        }
    }
}
