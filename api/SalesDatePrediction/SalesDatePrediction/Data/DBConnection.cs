using Dapper;
using Microsoft.Extensions.Options;
using SalesDatePrediction.Configuration;
using SalesDatePrediction.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace SalesDatePrediction.Data
{
    public class DBConnection : IDBConnection
    {
        private readonly string _connectionString;

        public DBConnection(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionString = connectionStrings.Value.DefaultConnection;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public async Task<IEnumerable<T>> Query<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return  await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<int> Execute(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<int> QuerySingleAsync(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return await connection.QuerySingleAsync<int>(sql, parameters);
            }
        }
    }
}
