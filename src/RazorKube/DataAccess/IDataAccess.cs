namespace RazorKube.DataAccess;

/// <summary>
/// Represents the data access layer.
/// </summary>
public interface IDataAccess
{
    /// <summary>
    /// Executes the given SQL.
    /// </summary>
    /// <param name="sql">The SQL to execute.</param>
    /// <returns>The SQL result.</returns>
    Task<T> ExecuteSql<T>(string sql);
}
