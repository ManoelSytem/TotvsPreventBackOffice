using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TotvsPreventBackOffice.Data;
using TotvsPreventBackOffice.Models;

namespace TotvsPreventBackOffice.Controllers
{
    public class ServidorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServidorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Servidor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servidor.ToListAsync());
        }

        // GET: Servidor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return View(servidor);
        }

        // GET: Servidor/Create
        public IActionResult Create()
        {
            Servidor serv = new Servidor();
            serv.DataCadastro = DateTime.Now;
            serv.DataAtualizacao = DateTime.Now;
            return View(serv);
        }

        // POST: Servidor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Endereco,Porta,DataCadastro,DataAtualizacao")] Servidor servidor)
        {
            if (ModelState.IsValid)
            {
                servidor.DataCadastro = DateTime.Now;
                servidor.DataAtualizacao = DateTime.Now;
                _context.Add(servidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servidor);
        }

        // GET: Servidor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidor.FindAsync(id);
            if (servidor == null)
            {
                return NotFound();
            }
            servidor.DataAtualizacao = DateTime.Now;
            return View(servidor);
        }

        // POST: Servidor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Endereco,Porta,DataCadastro,DataAtualizacao")] Servidor servidor)
        {
            if (id != servidor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    servidor.DataAtualizacao = DateTime.Now;
                    _context.Update(servidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServidorExists(servidor.Id))
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
            return View(servidor);
        }

        // GET: Servidor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servidor = await _context.Servidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servidor == null)
            {
                return NotFound();
            }

            return View(servidor);
        }

        // POST: Servidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servidor = await _context.Servidor.FindAsync(id);
            _context.Servidor.Remove(servidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServidorExists(int id)
        {
            return _context.Servidor.Any(e => e.Id == id);
        }
    }
}
