using Dapper;
using EBikeRentalsApp.DbAccessLayer;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Repository.Bikes
{
    public class BikesRepository<T> : IBikesRepository<T> where T : class
    {
        private readonly DatabaseConfig _databaseConfig;

        public BikesRepository(DatabaseConfig databaseConfig)
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

                var storedProcedureName = "dbo.GetAll_Bikes";

                await connection.OpenAsync();

                var result = await connection
                    .QueryAsync<T>(storedProcedureName,
                                   commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task InsertBike(T parameters)
        {
            using (var connection = CreateConnection())
            {
                var storedProcedureName = "dbo.sp_InsertBikes";

                await connection
                    .ExecuteAsync(storedProcedureName, 
                                   parameters,
                                   commandType: CommandType.StoredProcedure);

                
            }
        }
    }
}
