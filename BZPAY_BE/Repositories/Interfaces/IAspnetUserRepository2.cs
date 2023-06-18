using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for AspnetUser
    /// </summary>
    public interface IAspnetUserRepository2 : IGenericRepository<AspnetUser>
    {
        Task<AspnetUser?> GetUserByUserNameAsync(string username);
    }

}

