using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

// namespace SpecialTicket.BLL.Services.Implementations
namespace BZPAY_BE.BussinessLogic.auth.ServiceImplementation
{
    /// <summary>
    /// Service for Entrada
    /// </summary>
    public class EntradaService : IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;
        private readonly IConfiguration _config;

        public EntradaService()
        {
        }

        /// <summary>
        /// Constructor of EntradaService
        /// </summary>
        /// <param name="entradaRepository"></param>
        public EntradaService(IEntradaRepository entradaRepository, IConfiguration config)
        {
            _entradaRepository = entradaRepository;
            _config = config;   
        }

        public async Task<IEnumerable<Entrada>> GetAllEntradasAsync()
        {
            var lista = await _entradaRepository.GetAllEntradasAsync();
            return lista;
        }

        public async Task<Entrada> GetEntradaByIdAsync(int? id)
        {
             var lista = await _entradaRepository.GetEntradaByIdAsync(id);
             return lista;
        }
        public async Task<Entrada> GetEntradaByIdEventoAsync(int? id)
        {
            var lista = await _entradaRepository.GetEntradaByIdEventoAsync(id);
            return lista;
        }

        public async Task<Entrada> CreateEntradasAsync(Entrada entrada)
        {
            // Verificar primero si ya existen las entradas porque solo se pueden crear una vez
            var entradasEvento = await _entradaRepository.GetEntradaByIdEventoAsync(entrada.IdEvento);
            if (entradasEvento == null) // Si las entradas no han sido creadas --> crearlas
            {
                var nuevaEntrada = new Entrada();
                nuevaEntrada.IdEvento = entrada.IdEvento;
                nuevaEntrada.TipoAsiento = entrada.TipoAsiento;
                nuevaEntrada.Disponibles = entrada.Disponibles;
                nuevaEntrada.Precio = entrada.Precio;
                nuevaEntrada.Active = true;
                await _entradaRepository.AddAsync(nuevaEntrada);
            }
            return entradasEvento;
        }
    }
}