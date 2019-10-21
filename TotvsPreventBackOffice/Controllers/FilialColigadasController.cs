using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TotvsPreventBackOffice.Data;
using TotvsPreventBackOffice.Models;

namespace TotvsPreventBackOffice.Controllers
{
    public class FilialColigadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilialColigadasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FilialColigadas
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilialColigada.ToListAsync());
        }

        // GET: FilialColigadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filialColigada = await _context.FilialColigada
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filialColigada == null)
            {
                return NotFound();
            }

            return View(filialColigada);
        }

        // GET: FilialColigadas/Create
        public IActionResult Create()
        {
            ViewBag.Empresa = _context.Empresa.Select(e => new SelectListItem()
            { Text = e.Nome, Value = e.CodEmpresa }).ToList();
            return View();
        }

        // POST: FilialColigadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection filialColigada)
        {
            if (ModelState.IsValid)
            {
                FilialColigada nova = new FilialColigada();

                nova.Nome = filialColigada["Nome"];
                nova.CodigoFilialColigada = filialColigada["CodigoFilialColigada"];
                var empresa = _context.Empresa.Where(emp => emp.CodEmpresa == filialColigada["Empresa"]).FirstOrDefault();
                nova.Empresa = empresa;
                _context.Add(nova);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filialColigada);
        }

        // GET: FilialColigadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filialColigada = await _context.FilialColigada.FindAsync(id);
            if (filialColigada == null)
            {
                return NotFound();
            }
            return View(filialColigada);
        }

        // POST: FilialColigadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,CodigoFilialColigada")] FilialColigada filialColigada)
        {
            if (id != filialColigada.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filialColigada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialColigadaExists(filialColigada.ID))
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
            return View(filialColigada);
        }

        // GET: FilialColigadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filialColigada = await _context.FilialColigada
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filialColigada == null)
            {
                return NotFound();
            }

            return View(filialColigada);
        }

        // POST: FilialColigadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filialColigada = await _context.FilialColigada.FindAsync(id);
            _context.FilialColigada.Remove(filialColigada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialColigadaExists(int id)
        {
            return _context.FilialColigada.Any(e => e.ID == id);
        }
    }
}
