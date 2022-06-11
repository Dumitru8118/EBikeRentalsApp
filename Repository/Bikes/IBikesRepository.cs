using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikeRentalsApp.Repository.Bikes
{
    public interface IBikesRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetBikes();

        Task InsertBike(T t);
        //Task InsertBike(object p);
    }

}