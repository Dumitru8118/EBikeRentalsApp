using EBikeRentalsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Data
{
    public interface IBikeData
    {
        Task<IEnumerable<BikeModel>> GetBikes();
    }
}