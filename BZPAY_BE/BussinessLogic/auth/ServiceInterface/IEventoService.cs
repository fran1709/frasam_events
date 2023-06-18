using BZPAY_BE.Models;
using devTicket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.BussinessLogic.auth.ServiceInterface
{
    /// <summary>
    /// Service Interface for Evento. 
    /// </summary>
    
    public interface IEventoService
    {
        Task<IEnumerable<Evento>> GetAllEventosAsync();

        Task<Evento> GetEventoByIdAsync(int? id);

        Task<Evento> CreateEventoAsync(Evento evento);

        Task<Evento> UpdateEventoAsync(Evento evento);

        Task<IEnumerable<DetalleEvento>> GetDetalleEventosAsync();

        Task<EventoAsientos> GetEventoAsientosAsync(int? id);
    }
}
