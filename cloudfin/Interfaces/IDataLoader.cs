public interface IDataLoader
{
    Task<Company> LoadCompany(string code);
    Task<List<Company>> LoadCompanies();
    Task InsertCompany(Company company);
    Task UpdateCompany(Company company);
    Task DeleteCompany(string code);
}
