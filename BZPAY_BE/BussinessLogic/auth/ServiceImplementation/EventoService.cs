using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Interfaces;
using devTicket.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BZPAY_BE.BussinessLogic.auth.ServiceImplementation
{
    /// <summary>
    /// Service for Evento
    /// </summary>
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor of EventoService
        /// </summary>
        /// <param name="eventoRepository"></param>
        public EventoService(IEventoRepository eventoRepository, IConfiguration config)
        {
            _eventoRepository = eventoRepository;
            _config = config;
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync()
        {
            var lista = await _eventoRepository.GetAllEventosAsync();
            return lista;
        }

        public async Task<Evento> GetEventoByIdAsync(int? id)
        {
            var lista = await _eventoRepository.GetEventoByIdAsync(id);
            return lista;
        }

        public async Task<Evento> CreateEventoAsync(Evento evento)
        {
            var lista = await _eventoRepository.AddAsync(evento);
            return lista;
        }

        public async Task<Evento> UpdateEventoAsync(Evento evento)
        {
            var lista = await _eventoRepository.UpdateAsync(evento);
            return lista;
        }

        public async Task<IEnumerable<DetalleEvento>> GetDetalleEventosAsync()
        {
            var lista = await _eventoRepository.GetDetalleEventosAsync();
            return lista;
        }

        public async Task<EventoAsientos> GetEventoAsientosAsync(int? id)
        {
            var eventoAsientos = await _eventoRepository.GetEventoAsientosAsync(id);
            return eventoAsientos;
        } 
    }
}