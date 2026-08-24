using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ExampleMain.DataAccess;

/// <summary>
/// Class for managing the creation and opening of the database connection.
/// </summary>
public class DapperDbContext
{
    private readonly IDbConnection _dbConnection;

    /// <summary>
    /// Only constructor. Creates and opens a new database connection using the provided configuration.
    /// </summary>
    public DapperDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _dbConnection = new NpgsqlConnection(connectionString);
        _dbConnection.Open();
    }

    /// <summary>
    /// Access to the underlying database connection.
    /// </summary>
    public IDbConnection DbConnection => _dbConnection;
}