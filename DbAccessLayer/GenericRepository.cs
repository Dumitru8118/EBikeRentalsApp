using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EBikeRentalsApp.DbAccessLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseConfig _databaseConfig;

        public GenericRepository(DatabaseConfig databaseConfig)
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
    }
}
