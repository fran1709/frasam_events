using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Interfaces;
using BZPAY_UI.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BZPAY_BE.Repositories.Implementations
{
    public class AspnetUserRepository : GenericRepository<AspnetUser>, IAspnetUserRepository
    {
        /// <summary>
        /// Constructor of AspnetUserRepository
        /// </summary>
        /// <param name="membershipContext"></param>
        public AspnetUserRepository(dev_ticketContext dev_Ticket) : base(dev_Ticket)
        {
        }

        public async Task<AspnetUser?> GetUserByUserNameAsync(string username)
        {
            var user = await _context.Aspnetusers.SingleOrDefaultAsync(x => x.UserName == username);
            return user;
        }

        public async Task<AspnetUser?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Aspnetusers.SingleOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
