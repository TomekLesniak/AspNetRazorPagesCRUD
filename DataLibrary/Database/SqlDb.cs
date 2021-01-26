using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataLibrary.Database
{
    public class SqlDb : ISqlDb
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }
        
        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            var connectionString = _config.GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            var output = await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
            return output.ToList();
        }

        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            var connectionString = _config.GetConnectionString(connectionStringName);
            using IDbConnection connection = new SqlConnection(connectionString);
            int output =
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return output;
        }
    }
}
