using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UC_13_Kauan_LibraryOfOz_00001.Data;
using UC_13_Kauan_LibraryOfOz_00001.Models;

namespace UC_13_Kauan_LibraryOfOz_00001.Controllers
{
    public class AluguelsController : Controller
    {
        private readonly UC_13_Kauan_LibraryOfOz_00001Context _context;

        public AluguelsController(UC_13_Kauan_LibraryOfOz_00001Context context)
        {
            _context = context;
        }

        // GET: Aluguels
        public async Task<IActionResult> Index()
        {
            var uC_13_Kauan_LibraryOfOz_00001Context = _context.Aluguel.Include(a => a.NomeCliente).Include(a => a.NomeLivro);
            return View(await uC_13_Kauan_LibraryOfOz_00001Context.ToListAsync());
        }

        // GET: Aluguels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aluguel == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel
                .Include(a => a.NomeCliente)
                .Include(a => a.NomeLivro)
                .FirstOrDefaultAsync(m => m.AluguelId == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // GET: Aluguels/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente");
            ViewData["EstoqueId"] = new SelectList(_context.Estoque, "EstoqueId", "NomeLivro");
            return View();
        }

        // POST: Aluguels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AluguelId,EstoqueId,ClienteId,DataDevolucao")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", aluguel.ClienteId);
            ViewData["EstoqueId"] = new SelectList(_context.Estoque, "EstoqueId", "NomeLivro", aluguel.EstoqueId);
            return View(aluguel);
        }

        // GET: Aluguels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aluguel == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", aluguel.ClienteId);
            ViewData["EstoqueId"] = new SelectList(_context.Estoque, "EstoqueId", "NomeLivro", aluguel.EstoqueId);
            return View(aluguel);
        }

        // POST: Aluguels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AluguelId,EstoqueId,ClienteId,DataDevolucao")] Aluguel aluguel)
        {
            if (id != aluguel.AluguelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguelExists(aluguel.AluguelId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", aluguel.ClienteId);
            ViewData["EstoqueId"] = new SelectList(_context.Estoque, "EstoqueId", "NomeLivro", aluguel.EstoqueId);
            return View(aluguel);
        }

        // GET: Aluguels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aluguel == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel
                .Include(a => a.NomeCliente)
                .Include(a => a.NomeLivro)
                .FirstOrDefaultAsync(m => m.AluguelId == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // POST: Aluguels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aluguel == null)
            {
                return Problem("Entity set 'UC_13_Kauan_LibraryOfOz_00001Context.Aluguel'  is null.");
            }
            var aluguel = await _context.Aluguel.FindAsync(id);
            if (aluguel != null)
            {
                _context.Aluguel.Remove(aluguel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguelExists(int id)
        {
          return (_context.Aluguel?.Any(e => e.AluguelId == id)).GetValueOrDefault();
        }
    }
}
