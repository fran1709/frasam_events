using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BZPAY_UI.Repositories.Implementations;
using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;

namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for Entrada
    /// </summary>
    public class EntradaRepository : GenericRepository<Entrada>, IEntradaRepository
    {
        /// <summary>
        /// Constructor of EntradaRepository
        /// </summary>
        /// <param name="specialTicketContext"></param>
        public EntradaRepository(dev_ticketContext _context) : base(_context)
        {
        }

        public Task<Entrada> CreateEntradasAsync(Entrada entrada)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Entrada>> GetAllEntradasAsync()
        {
            var listaEventos = (from E in _context.Entradas
                                where E.Active
                                orderby E.Id ascending
                                select new Entrada
                                {
                                    Id = E.Id,
                                    TipoAsiento = E.TipoAsiento,
                                    Precio = E.Precio
                                    
                                }).ToListAsync();
            return await listaEventos;
        }

        public async Task<Entrada> GetEntradaByIdAsync(int? id)
        {
            var entrada = await(from E in _context.Entradas
                                where E.Id == id && E.Active == true
                                select E).FirstOrDefaultAsync();
            return entrada;
        }

        public async Task<Entrada> GetEntradaByIdEventoAsync(int? idEntrada)
        {
            var entrada = await (from E in _context.Entradas
                                join Ev in _context.Eventos on E.IdEvento equals Ev.Id
                                where Ev.Id == idEntrada
                                 select new Entrada { Id = E.Id, IdEvento = E.IdEvento, Active = E.Active }).FirstOrDefaultAsync();
            return entrada;

        }

       
    }
}