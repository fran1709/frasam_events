using BZPAY_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.BussinessLogic.auth.ServiceInterface
{
    /// <summary>
    /// Service Interface for TipoEvento. 
    /// </summary>
    
    public interface ITipoEventoService
    {

        Task<IEnumerable<TipoEvento>> GetAllTipoEventosAsync();
    }
}
