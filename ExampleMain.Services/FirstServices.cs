using ExampleMain.DataAccess;
using ExampleMain.Services.Interfaces;
using Dapper;

namespace ExampleMain.Services;

public class FirstService : IFirstService
{
    private readonly DapperDbContext _dbContext;

    public FirstService(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DoTheThing()
    {
        var result = await _dbContext.DbConnection.QueryAsync("SELECT * FROM plant_type");
    }
}