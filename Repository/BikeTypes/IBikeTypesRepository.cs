using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Repository.BikeTypes
{
    public interface IBikeTypesRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetBikes();
    }
}