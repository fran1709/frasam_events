using BZPAY_BE.Models;

namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for AspnetUser
    /// </summary>
    public interface IAspnetUserRepository : IGenericRepository<AspnetUser>
    {
        Task<AspnetUser?> GetUserByUserNameAsync(string username);
        Task<AspnetUser?> GetUserByEmailAsync(string email);
    }

}
