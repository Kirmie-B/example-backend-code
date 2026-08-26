using Dapper;
using System.Data;

namespace Garden.DataAccess;

/// <summary>
/// The class wraps calls made through Dapper so that the can be properly mocked and tested. Attempting to use Moq.Dapper results in very losely
/// checked mock setups and lots of false positives. There are also a number of other issues present with mocking and Dapper where this override
/// is more effective.
/// </summary>
public class DapperWrapper : IDapperWrapper
{
    /// <summary>
    /// Executes a pass through to <see cref="IDbConnection.QueryAsync{T}"/> so that it can be properly mocked.
    /// </summary>
    /// <typeparam name="T">The type of data returned by the query.</typeparam>
    /// <param name="connection">The database connection to use for the query</param>
    /// <param name="sql">The SQL query to execute.</param>
    /// <param name="param">The optional parameters to pass into the query. Defaults to null.</param>
    /// <param name="dbTransaction">The optional database transaction to use for the query. Defaults to null.</param>
    /// <param name="commandTimeout">The optional command timeout to use for the query. Defaults to null.</param>
    /// <param name="commandType">The optional command type to use for the query. Defaults to null.</param>
    /// <returns>A task that can run the query and return the results as an enumerable of type <typeparamref name="T"/>.</returns>
    public Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql, object? param = null, IDbTransaction? dbTransaction = null, 
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return connection.QueryAsync<T>(sql, param, dbTransaction, commandTimeout, commandType);
    }
}