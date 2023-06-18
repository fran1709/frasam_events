using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BZPAY_UI.Repositories.Implementations;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Interfaces;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for TipoEvento
    /// </summary>
    public class TipoEventoRepository : GenericRepository<TipoEvento>, ITipoEventoRepository
    {
        /// <summary>
        /// Constructor of TipoEventoRepository
        /// </summary>
        /// <param name="specialTicketContext"></param>
        public TipoEventoRepository(dev_ticketContext _context) : base(_context)
        {   
        }

        public async Task<IEnumerable<TipoEvento>> GetAllTipoEventosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TipoEvento> GetTipoEventoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}