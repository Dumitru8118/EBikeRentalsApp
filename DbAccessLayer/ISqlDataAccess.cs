using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBikeRentalsApp.DbAccessLayer
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadBikes<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "DefaultConnection");
    }
}