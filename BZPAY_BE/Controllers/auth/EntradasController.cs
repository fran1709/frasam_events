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

namespace devTicket.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EntradasController : Controller
    {

        private readonly IEntradaService _service;

        public EntradasController(IEntradaService service) => _service = service;

        // GET: Entradas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entrada>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetAllEntradasAsync()
        {
            IEnumerable<Entrada> result = await _service.GetAllEntradasAsync();
            return (result is null) ? NotFound() : Ok(result);
        }

        // GET: Entradas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entrada>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetEntradaByIdAsync(int? id)
        {
            Entrada result  = await _service.GetEntradaByIdAsync(id);
            return (result is null) ? NotFound() : Ok(result);
        }

        // GET: Entradas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Entrada>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetEntradaByIdEventoAsync(int? id)
        {
            Entrada result = await _service.GetEntradaByIdEventoAsync(id);
            return (result is null) ? NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Evento), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Entrada>> CreateEntradaAsync([FromBody] Entrada entrada)
        {
            if (entrada is null)
            {
                return BadRequest();
            }

            Entrada createdEntrada = await _service.CreateEntradasAsync((IFormCollection)entrada);

            return CreatedAtAction(nameof(GetEntradaByIdAsync), new { id = createdEntrada.Id }, createdEntrada);
        }


        /*private readonly dev_ticketContext _context;

        public EntradasController(dev_ticketContext context)
        {
            _context = context;
        }

        // GET: Entradas
        public async Task<IActionResult> Index()
        {
            var devTicketContext = _context.Entradas.Include(e => e.IdEventoNavigation);
            return View(await devTicketContext.ToListAsync());
        }

        // GET: Entradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas
                .Include(e => e.IdEventoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // GET: Entradas/Create
        public IActionResult Create()
        {
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "Id");
            return View();
        }

        // POST: Entradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoAsiento,Disponibles,Precio,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdEvento")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "Id", entrada.IdEvento);
            return View(entrada);
        }

        // GET: Entradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "Id", entrada.IdEvento);
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoAsiento,Disponibles,Precio,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdEvento")] Entrada entrada)
        {
            if (id != entrada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaExists(entrada.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "Id", entrada.IdEvento);
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas
                .Include(e => e.IdEventoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entradas == null)
            {
                return Problem("Entity set 'DevTicketContext.Entradas'  is null.");
            }
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada != null)
            {
                _context.Entradas.Remove(entrada);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
          return (_context.Entradas?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
