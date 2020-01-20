using System.Threading.Tasks;
using CodeChallenge.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeChallenge.Controllers
{
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CompanyController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Company.ToListAsync() });
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _db.Company.FirstOrDefaultAsync(q => q.Id == id);

            if (company != null)
                return Ok(company);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("[action]/{isin}")]
        public async Task<IActionResult> GetCompanyByIsin(string isin)
        {
            var company = await _db.Company.FirstOrDefaultAsync(q => q.Isin == isin);

            if (company != null)
                return Ok(company);
            else
                return NotFound();
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> CreateCompany(Company company)
        {
            //Check company exist
            var companyDB = await _db.Company.FirstOrDefaultAsync(q => q.Id == company.Id);

            if (companyDB == null)
            {
                //ISIN validation
                if (IsIsinValid(company.Isin))
                {
                    //Control isin
                    var isIsinExist = await _db.Company.FirstOrDefaultAsync(q => q.Isin == company.Isin) != null;

                    //Add company
                    if (!isIsinExist)
                        _db.Company.Add(company);
                    else
                        return BadRequest("ISIN is already exist.");
                }
                else
                    return BadRequest("The first two characters of an ISIN must be letters.");
            }
            else
                return BadRequest("Company is already exist.");

            await _db.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdateCompany(Company company)
        {
            //Check company exist
            var companyDB = await _db.Company.FirstOrDefaultAsync(q => q.Id == company.Id);

            if (companyDB != null)
            {
                //ISIN validation
                if (IsIsinValid(company.Isin))
                {
                    //Control isin
                    var isIsinExist = await _db.Company.FirstOrDefaultAsync(q => q.Id != company.Id && q.Isin == company.Isin) != null;

                    if(!isIsinExist)
                        _db.Company.Update(company);
                    else
                        return BadRequest("Isin is already exist");
                }
                
                else
                    return BadRequest("The first two characters of an ISIN must be letters.");
            }
            else
                return BadRequest("Company cannot be found.");

            await _db.SaveChangesAsync();

            return Ok();
        }

        private bool IsIsinValid(string isin)
        {
            //The first two characters of an ISIN must be letters
            if (!char.IsDigit(isin[0]) && !char.IsDigit(isin[1]))
                return true;
            else
                return false;
        }

    }
}
