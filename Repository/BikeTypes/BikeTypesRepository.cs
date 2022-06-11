using Dapper;
using EBikeRentalsApp.DbAccessLayer;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Repository.BikeTypes
{
    public class BikeTypesRepository<T> : IBikeTypesRepository<T> where T : class
    {
        private readonly DatabaseConfig _databaseConfig;
        public BikeTypesRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_databaseConfig.Name);
        }
        public async Task<IEnumerable<T>> GetBikes()
        {
            using (var connection = CreateConnection())
            {

                var storedProcedureName = "dbo.GetAll_BikeTypes";

                await connection.OpenAsync();

                var result = await connection
                    .QueryAsync<T>(storedProcedureName,
                                   commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
