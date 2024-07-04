public static class CompanyMapper
{
    public static Company Map(SqlServerLoader.Trader trader)
    {
        return new Company
        {
            Code = trader.Code,
            Address = trader.Street,
            Description = trader.Description
        };
    }

    public static SqlServerLoader.Trader MapToTrader(Company company)
    {
        return new SqlServerLoader.Trader
        {
            Code = company.Code,
            Street = company.Address,
            Description = company.Description
        };
    }

    public static Company Map(FileLoader.Supplier supplier)
    {
        return new Company
        {
            Code = supplier.Id,
            Address = supplier.Address,
            Description = supplier.Name
        };
    }

    public static FileLoader.Supplier MapToSupplier(Company company)
    {
        return new FileLoader.Supplier
        {
            Id = company.Code,
            Address = company.Address,
            Name = company.Description
        };
    }
}
