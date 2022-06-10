using EBikeRentalsApp.DbAccessLayer;
using EBikeRentalsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Data
{
    public class BikeData : IBikeData
    {
        private readonly ISqlDataAccess _db;

        public BikeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<BikeModel>> GetBikes() =>
            _db.LoadBikes<BikeModel, dynamic>(
                storedProcedure: "dbo.GetAll_Bikes",
                new { }
                );
    }
}
