namespace Common.DbHelper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;

    /// <summary>
    ///  Purpose of this interface is connect with database and return result in dynamic object.
    /// </summary>
    public interface IDbHelper
    {
        /// <summary>
        /// Purpose of this method is to create a connection of SQL.
        /// </summary>
        /// <param name="connectionstring">db connection string to open connection.</param>
        /// <returns>return the sql connection instance.</returns>
        IDbConnection CreateConnection();

        /// <summary>
        /// When SP or query return single table then use this method.
        /// </summary>
        /// <typeparam name="T">Known type of class.</typeparam>
        /// <param name="query">name of SP.</param>
        /// <param name="dynamicParameters">list of stored procedures paramter.</param>
        /// <returns>return the result from database.</returns>
        Task<IEnumerable<T>> SelectDataList<T>(string query, DynamicParameters dynamicParameters = null);

        /// <summary>
        /// Use this method for add new Entity in system.
        /// </summary>
        /// <typeparam name="TInput">Entity which is required to add.</typeparam>
        /// <typeparam name="TReturn">Value that is returned.</typeparam>
        /// <param name="entity">name of entity.</param>
        /// <returns>return GUID if succeed.</returns>
        Task<TReturn> InsertAsync<TInput, TReturn>(TInput entity);

        /// <summary>
        /// Use this method for update existing Entity in system.
        /// </summary>
        /// <typeparam name="T">Entity which is required to add.</typeparam>
        /// <param name="entity">name of entity.</param>
        /// <returns>return GUID if succeed.</returns>
        Task<int> UpdateAsync<T>(T entity);

        /// <summary>
        /// Get single object from entity by Primary Key.
        /// </summary>
        /// <typeparam name="T">Type of Entity.</typeparam>
        /// <param name="id">primary key GUID.</param>
        /// <returns>Entity Object.</returns>
        Task<T> GetByIdAsync<T>(Guid id);

        /// <summary>
        /// Get List of Entities by Parameters.
        /// </summary>
        /// <typeparam name="T">Type of Entity.</typeparam>
        /// <param name="sql">SQL query.</param>
        /// <param name="param">Parameter Object.</param>
        /// <returns>List of T Entity.</returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);

        /// <summary>
        /// Get single object from entity by Params.
        /// </summary>
        /// <typeparam name="T">Type of Entity.</typeparam>
        /// <param name="sql">SQL query.</param>
        /// <param name="param">Parameter Object.</param>
        /// <returns>T Entity.</returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null);

        /// <summary>
        /// Execute a command asynchronously using Task.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteAsync(string sql, object param = null);

        /// <summary>
        /// Execute parameterized sql that returns single value.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="sql">SQL Query.</param>
        /// <param name="param">Parameter Object.</param>
        /// <returns>DB returned value.</returns>
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <typeparam name="T">entity model type.</typeparam>
        /// <param name="entity">entity.</param>
        /// <returns>no of rows effected.</returns>
        Task<int> DeleteAsync<T>(T entity);
    }
}
