using System.Data;
using Dapper;
using Npgsql;

namespace RazorKube.DataAccess;

/// <summary>
/// Represents a data access layer implementation.
/// </summary>
public class DataAccess : IDataAccess
{
    /// <summary>
    /// Database connection.
    /// </summary>
    private readonly IDbConnection _dbConnection;

    /// <summary>
    /// Constructs a new instance of <see cref="DataAccess"/>.
    /// </summary>
    /// <param name="connString">The connection string.</param>
    public DataAccess(string connString)
    {
        _dbConnection = new NpgsqlConnection(connString);
        _dbConnection.Open();
    }

    /// <inheritdoc cref="IDataAccess.ExecuteSql{T}"/>
    public Task<T> ExecuteSql<T>(string sql)
    {
        return _dbConnection.QueryFirstAsync<T>(sql);
    }
}
