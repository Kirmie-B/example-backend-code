using System.Data;

namespace Garden.DataAccess;

/// <summary>
/// Interface for managing the creation and opening of the database connection.
/// </summary>
public interface IDapperDbContext
{
    /// <summary>
    /// Access to the underlying database connection.
    /// </summary>
    IDbConnection DbConnection { get; }
}