using api.Models.DatabaseObjects;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly IRepository<Company> companyRepo;
        public CompanyController(IRepository<Company> companyRepo)
        {
            this.companyRepo = companyRepo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var companies = await companyRepo.Get();

            return Ok(companies);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await companyRepo.Get(id);

            if (company != null)
            {
                return Ok(company);
            }

            return NotFound();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            await companyRepo.Create(company);
            return Ok(company);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Company company)
        {
            await companyRepo.Update(company);

            return Ok(company);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await companyRepo.Delete(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
