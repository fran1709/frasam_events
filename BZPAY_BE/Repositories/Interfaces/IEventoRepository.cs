using BZPAY_BE.Models;
using devTicket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// namespace SpecialTicket.DAL.Repositories.Interfaces
namespace BZPAY_BE.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for Evento
    /// </summary>
    public interface IEventoRepository : IGenericRepository<Evento>
    {
        Task<IEnumerable<Evento>> GetAllEventosAsync();
        Task<Evento> GetEventoByIdAsync(int? id);
        Task<IEnumerable<DetalleEvento>> GetDetalleEventosAsync();
        Task<EventoAsientos> GetEventoAsientosAsync(int? id);
    }

}

