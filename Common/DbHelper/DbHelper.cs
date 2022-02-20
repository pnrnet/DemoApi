
namespace Common.DbHelper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    using static Dapper.SqlMapper;

    /// <summary>
    /// Purpose of this class is connect with database and return result in dynamic object.
    /// </summary>
    public class DbHelper : IDbHelper
    {
        private readonly DatabaseOptions databaseOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbHelper"/> class.
        /// </summary>
        /// <param name="databaseOptions">Db Connection Properties.</param>
        public DbHelper(DatabaseOptions databaseOptions)
        {
            this.databaseOptions = databaseOptions;
        }
        /// <inheritdoc/>
        public IDbConnection CreateConnection()
        {
            string connectionString = databaseOptions.DBConnection;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new System.ArgumentException($"'{nameof(connectionString)}' cannot be null or empty.", nameof(connectionString));
            }

            IDbConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public Task<int> DeleteAsync<T>(T entity)
        {
            using (var connection = CreateConnection())
            {
                return connection.DeleteAsync<T>(entity);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(sql, param);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteScalarAsync<T>(sql, param);
            }
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
        {
            using (var connection = CreateConnection())
            {
                return await connection.GetAsync<T>(id);
            }
        }

        public async Task<TReturn> InsertAsync<TInput, TReturn>(TInput entity)
        {
            using (var connection = CreateConnection())
            {
                return await connection.InsertAsync<TReturn, TInput>(entity);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(sql, param);
            }
        }

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> SelectDataList<T>(string query, DynamicParameters dynamicParameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(query, dynamicParameters);
            }
        }

        public async Task<int> UpdateAsync<T>(T entity)
        {
            using (var connection = CreateConnection())
            {
                return await connection.UpdateAsync<T>(entity);
            }
        }
    }
}
