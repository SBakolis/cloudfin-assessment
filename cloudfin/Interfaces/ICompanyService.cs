public interface ICompanyService
{
    Task<IEnumerable<Company>> GetAllCompanies();
    Task<Company> GetCompanyByCode(string code);
    Task AddCompany(Company company);
    Task UpdateCompany(Company company);
    Task DeleteCompany(string code);
}