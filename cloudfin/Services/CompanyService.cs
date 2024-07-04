public class CompanyService : ICompanyService
{
    private readonly IDataLoader _dataLoader;

    public CompanyService(IDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }

    public async Task<IEnumerable<Company>> GetAllCompanies()
    {
        return await _dataLoader.LoadCompanies();
    }

    public async Task<Company> GetCompanyByCode(string code)
    {
        return await _dataLoader.LoadCompany(code);
    }

    public async Task AddCompany(Company company)
    {
        await _dataLoader.InsertCompany(company);
    }

    public async Task UpdateCompany(Company company)
    {
        await _dataLoader.UpdateCompany(company);
    }

    public async Task DeleteCompany(string code)
    {
        await _dataLoader.DeleteCompany(code);
    }
}
