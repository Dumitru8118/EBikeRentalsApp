using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikeRentalsApp.DbAccessLayer
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetBikes();
    }
}