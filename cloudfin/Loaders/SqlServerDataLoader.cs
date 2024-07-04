using SqlServerLoader;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SqlServerDataLoader : IDataLoader
{
    private readonly DataLoader _dataLoader;

    public SqlServerDataLoader()
    {
        _dataLoader = new DataLoader("server", "userid", "password");
    }

    public async Task<Company> LoadCompany(string code)
    {
        var trader = await _dataLoader.LoadTrader(code);
        return CompanyMapper.Map(trader);
    }

    public async Task<List<Company>> LoadCompanies()
    {
        var traders = await _dataLoader.LoadTraders();
        return traders.Select(CompanyMapper.Map).ToList();
    }

    public async Task InsertCompany(Company company)
    {
        var trader = CompanyMapper.MapToTrader(company);
        await _dataLoader.InsertTrader(trader);
    }

    public async Task UpdateCompany(Company company)
    {
        var trader = CompanyMapper.MapToTrader(company);
        await _dataLoader.UpdateTrader(trader);
    }

    public async Task DeleteCompany(string code)
    {
        await _dataLoader.DeleteTrader(code);
    }
}
