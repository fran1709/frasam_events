using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using devTicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BZPAY_BE.BussinessLogic.auth.ServiceInterface
{
    /// <summary>
    /// Service Interface for Entrada. 
    /// </summary>
    
    public interface IEntradaService
    {
        Task<IEnumerable<Entrada>> GetAllEntradasAsync();

        Task<Entrada> GetEntradaByIdAsync(int? id);

        Task<Entrada> GetEntradaByIdEventoAsync(int? id);

        Task<Entrada> CreateEntradasAsync(Entrada entrada);

        Task<IEnumerable<DetalleEntrada>> GetDetalleEntradaAsync();

    }
}
