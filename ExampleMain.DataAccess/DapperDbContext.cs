using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ExampleMain.DataAccess;

public class DapperDbContext
{
    private readonly IDbConnection _dbConnection;

        public DapperDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => _dbConnection;
}