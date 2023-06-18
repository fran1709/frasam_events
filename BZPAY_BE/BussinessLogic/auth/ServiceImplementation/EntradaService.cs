﻿using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Entrada> CreateEntradasAsync(IFormCollection collection)
        {
            var form = collection.ToList();
            var idEvento = Int32.Parse(form[0].Value);
            //verificar primero si ya existen las entradas porque solo se pueden crear una vez
            var entradasEvento = await _entradaRepository.GetEntradaByIdEventoAsync(idEvento);
            if (entradasEvento == null)//si entradas no han sido creadas --> crearlas
            {
                var descripciones = form[1].Value.ToList();
                var cantidades = form[2].Value.ToList();
                var precios = form[3].Value.ToList();
                for (var i = 0; i < descripciones.Count(); i++)
                {
                    var entrada = new Entrada();
                    entrada.IdEvento = idEvento;
                    entrada.TipoAsiento = descripciones[i];
                    entrada.Disponibles = Int32.Parse(cantidades[i]);
                    entrada.Precio = Decimal.Parse(precios[i]);
                    entrada.Active = true;
                    await _entradaRepository.AddAsync(entrada);
                }
            }
            return entradasEvento;
        }



    }
}