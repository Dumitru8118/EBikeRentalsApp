using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikeRentalsApp.DbAccessLayer
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadBikes<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(
                _config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
            
        }
    }
}
