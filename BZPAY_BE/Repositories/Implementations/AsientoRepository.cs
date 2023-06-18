﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BZPAY_UI.Repositories.Implementations;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Interfaces;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for Asiento
    /// </summary>
    public class AsientoRepository : GenericRepository<Asiento>, IAsientoRepository
    {
        /// <summary>
        /// Constructor of AsientoRepository
        /// </summary>
        /// <param name="specialTicketContext"></param>
        public AsientoRepository(dev_ticketContext _context) : base(_context)
        {   
        }

        public async Task<IEnumerable<Asiento>> GetAllAsientosAsync()
        {
            return await _context.Asientos
                                 .Include(t => t.IdEscenarioNavigation)
                                 .Where(t => t.Active)
                                 .ToListAsync();
        }

        public async Task<Asiento> GetAsientosByIdAsync(int id)
        {
            return await _context.Asientos
                                 .Where(t => t.Active)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}