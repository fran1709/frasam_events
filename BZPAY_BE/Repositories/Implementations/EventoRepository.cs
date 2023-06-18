using Microsoft.EntityFrameworkCore;
    
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BZPAY_UI.Repositories.Implementations;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Interfaces;
using devTicket.Models;
using devTicket.Models.Entities;

// namespace SpecialTicket.DAL.Repositories.Implementations
namespace BZPAY_BE.Repositories.Implementations
{
    /// <summary>
    /// Repository for Evento
    /// </summary>
    public class EventoRepository : GenericRepository<Evento>, IEventoRepository
    {

        public EventoRepository(dev_ticketContext _context) : base(_context)
        {   
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync()
        {
            var listaEventos = (from E in _context.Eventos
                                where E.Active
                                orderby E.Id ascending
                                select new Evento
                                {
                                    Id = E.Id,
                                    Descripcion = E.Descripcion
                                }).ToListAsync();
            return await listaEventos;
        }

        public async Task<Evento> GetEventoByIdAsync(int? id)
        {
            var evento = await (from E in _context.Eventos
                                join TE in _context.TipoEventos on E.IdTipoEvento equals TE.Id
                                join TES in _context.TipoEscenarios on E.IdEscenario equals TES.Id
                                where E.Id == id
                          select new Evento
                          {
                              Id = E.Id,
                              Descripcion = E.Descripcion,
                              IdTipoEvento = E.IdTipoEvento,
                              IdEscenario = E.IdEscenario
                          }).FirstOrDefaultAsync();
            return evento;
                          
        }

        public async Task<IEnumerable<DetalleEvento>> GetDetalleEventosAsync()
        {
            var listaEventos = (from E in _context.Eventos
                                 join TE in _context.TipoEventos on E.IdTipoEvento equals TE.Id
                                 join ESC in _context.Escenarios on E.IdEscenario equals ESC.Id
                                 join TESC in _context.TipoEscenarios on ESC.Id equals TESC.IdEscenario
                                 where E.Active
                                 orderby E.Id ascending
                                 select new DetalleEvento
                                 {
                                     Id = E.Id,
                                     Descripcion = E.Descripcion,
                                     TipoEvento = TE.Descripcion,
                                     Fecha = E.Fecha,
                                     TipoEscenario = TESC.Descripcion,
                                     Escenario = ESC.Nombre,
                                     Localizacion = ESC.Localizacion
                                 }).ToListAsync();
            return await listaEventos;
        }

        public async Task<EventoAsientos> GetEventoAsientosAsync(int? id)
        {
            var evento = await _context.Eventos
                                       .Include(esc => esc.IdEscenarioNavigation)
                                       .ThenInclude(tesc => tesc.TipoEscenarios)
                                       .Include(te => te.IdTipoEventoNavigation)
                                       .Where(e => e.Active && e.Id == id)
                                       .Select(e => new DetalleEvento
                                       {
                                           Id = e.Id,
                                           Descripcion = e.Descripcion,
                                           TipoEvento = e.IdTipoEventoNavigation.Descripcion,
                                           Fecha = e.Fecha,
                                           TipoEscenario = e.IdEscenarioNavigation.TipoEscenarios.Select(te => te.Descripcion).FirstOrDefault(),
                                           Escenario = e.IdEscenarioNavigation.Nombre,
                                           Localizacion = e.IdEscenarioNavigation.Localizacion
                                       }).FirstOrDefaultAsync();

            var asientos = await (from E in _context.Eventos
                                  join ESC in _context.Escenarios on E.IdEscenario equals ESC.Id
                                  join AS in _context.Asientos on ESC.Id equals AS.IdEscenario
                                  where E.Active && AS.Active && E.Id == id
                                  orderby E.Id ascending
                                  select new AsientoPrecio
                                  {
                                      Id = AS.Id,
                                      Descripcion = AS.Descripcion,
                                      Cantidad = AS.Cantidad,
                                      Precio = 0
                                  }).ToListAsync();

            var eventoAsientos = new EventoAsientos
            {
                Id = evento.Id,
                Descripcion = evento.Descripcion,
                TipoEvento = evento.TipoEvento,
                Fecha = evento.Fecha,
                TipoEscenario = evento.TipoEscenario,
                Escenario = evento.Escenario,
                Localizacion = evento.Localizacion,
                Asientos = asientos
            };

            return eventoAsientos;
        }

        //public async Task<Evento> GetEventByIdAsync(int id)
        //{
        //    var evento = await _context.Eventos
        //        .Include(e => e.IdEscenarioNavigation)
        //        .Include(e => e.IdTipoEventoNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    return evento;
        //}

        //public async Task<IEnumerable<Evento>> GetDetallesEventosAsync()
        //{
        //   var listaEventos = (from E in _context.Eventos
        //                         join TE in _context.TipoEventos on E.IdTipoEvento equals TE.Id
        //                         join ESC in _context.Escenarios on E.IdEscenario equals ESC.Id
        //                         join TESC in _context.TipoEscenarios on ESC.Id equals TESC.IdEscenario
        //                         where E.Active
        //                         orderby E.Id ascending
        //                         select new {
        //                                Id = E.Id,
        //                                Descripcion = E.Descripcion,
        //                                TipoEvento = TE.Descripcion,
        //                                Fecha = E.Fecha,
        //                                TipoEscenario = TESC.Descripcion,
        //                                Escenario = ESC.Nombre,
        //                                Localizacion = ESC.Localizacion
        //                         }).ToListAsync();


        //    return (IEnumerable<Evento>)await listaEventos; 
        //}
    }
}