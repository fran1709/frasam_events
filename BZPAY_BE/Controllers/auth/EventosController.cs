using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using devTicket.Models;
using BZPAY_BE.Models;
using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.DataAccess;

namespace BZPAY_BE.Controllers
{
    [Route("api/[controller]/[action]")]

    public class EventoController : Controller
    {
        private readonly IEventoService _service;
        /*La línea "_service = service;" asigna la instancia del servicio proporcionado a una variable privada 
         * llamada "_service" dentro del controlador. Esto permite que el controlador acceda y utilice los métodos 
         * y funcionalidades expuestas por el servicio a través de la variable "_service".*/
        public EventoController(IEventoService service) => _service = service;

        // GET: Eventos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Evento>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Evento>>> GetAllEventosAsync()
        {
            IEnumerable<Evento> result = await _service.GetAllEventosAsync();
            return (result is null) ? NotFound() : Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Evento), StatusCodes.Status200OK)]
        public async Task<ActionResult<Evento>> GetEventoByIdAsync(int? id)
        {
            Evento result = await _service.GetEventoByIdAsync(id);
            return (result is null) ? NotFound() : Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<DetalleEvento>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DetalleEvento>>> GetDetalleEventosAsync()
        {
            IEnumerable<DetalleEvento> result = await _service.GetDetalleEventosAsync();
            return (result is null) ? NotFound() : Ok(result);
        }


    }
}
