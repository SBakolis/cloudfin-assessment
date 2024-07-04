using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
    {
        return Ok(await _companyService.GetAllCompanies());
    }

    [HttpGet("{code}")]
    public async Task<ActionResult<Company>> GetCompanyByCode(string code)
    {
        var company = await _companyService.GetCompanyByCode(code);
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company);
    }

    [HttpPost]
    public async Task<ActionResult> AddCompany([FromBody] Company company)
    {
        await _companyService.AddCompany(company);
        return CreatedAtAction(nameof(GetCompanyByCode), new { code = company.Code }, company);
    }

    [HttpPut("{code}")]
    public async Task<ActionResult> UpdateCompany(string code, [FromBody] Company company)
    {
        if (code != company.Code)
        {
            return BadRequest();
        }

        await _companyService.UpdateCompany(company);
        return NoContent();
    }

    [HttpDelete("{code}")]
    public async Task<ActionResult> DeleteCompany(string code)
    {
        await _companyService.DeleteCompany(code);
        return NoContent();
    }
}
