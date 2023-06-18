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
    /// Repository for Escenario
    /// </summary>
    public class EscenarioRepository : GenericRepository<Escenario>, IEscenarioRepository
    {
        /// <summary>
        /// Constructor of EscenarioRepository
        /// </summary>
        /// <param name="specialTicketContext"></param>
        public EscenarioRepository(dev_ticketContext Context) : base(Context)
        {   
        }

        public async Task<IEnumerable<Escenario>> GetAllEscenariosAsync()
        {
            return await _context.Escenarios.ToListAsync();
        }

        public async Task<Escenario> GetEscenarioByIdAsync(int? id)
        {
            return await _context.Escenarios
                                 .Where(t => t.Active)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }


    }
}