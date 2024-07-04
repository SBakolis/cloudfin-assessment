using FileLoader;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FileDataLoader : IDataLoader
{
    private readonly Loader _loader;

    public FileDataLoader()
    {
        _loader = new Loader("suppliers.txt");
    }

    public Task<Company> LoadCompany(string code)
    {
        var supplier = _loader.LoadSupplier(code);
        return Task.FromResult(CompanyMapper.Map(supplier));
    }

    public Task<List<Company>> LoadCompanies()
    {
        var suppliers = _loader.LoadSuppliers();
        return Task.FromResult(suppliers.Select(CompanyMapper.Map).ToList());
    }

    public Task InsertCompany(Company company)
    {
        var supplier = CompanyMapper.MapToSupplier(company);
        _loader.InsertSupplier(supplier);
        return Task.CompletedTask;
    }

    public Task UpdateCompany(Company company)
    {
        var supplier = CompanyMapper.MapToSupplier(company);
        _loader.UpdateSupplier(supplier);
        return Task.CompletedTask;
    }

    public Task DeleteCompany(string code)
    {
        _loader.DeleteSupplier(code);
        return Task.CompletedTask;
    }
}
