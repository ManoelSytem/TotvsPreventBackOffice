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
    public class MetodoApisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MetodoApisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MetodoApis
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodoApi.ToListAsync());
        }

        // GET: MetodoApis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoApi = await _context.MetodoApi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (metodoApi == null)
            {
                return NotFound();
            }

            return View(metodoApi);
        }

        // GET: MetodoApis/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Servidor = _context.Servidor.Select(serv => new SelectListItem()
            { Text = serv.Endereco, Value = serv.Id.ToString() }).ToList();
            ViewBag.Modulo = _context.Modulo.Select(e => new SelectListItem()
            { Text = e.descricao, Value = e.Id.ToString() }).ToList();
            return View();
        }

        public JsonResult Create(string idServidor, string idModulo, string metodo)
        {
            try
            {
                MetodoApi novo = new MetodoApi();

                novo.Metodo = metodo;
                novo.DataCadastro = DateTime.Now;
                novo.DataAtualizacao = DateTime.Now;
                int id = Convert.ToInt32(idServidor);
                var servidor = _context.Servidor.Where(serv => serv.Id == id).FirstOrDefault();
                novo.Servidor = servidor;
                novo.ModuloId = Convert.ToInt32(idModulo);
                _context.Add(novo);
                _context.SaveChangesAsync();
                return Json(new { sucesso = "Metodo criado com sucesso!" });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    msg = e.Message,
                    erro = true
                });
            }

        }

        // GET: MetodoApis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoApi = await _context.MetodoApi.FindAsync(id);
            if (metodoApi == null)
            {
                return NotFound();
            }
            metodoApi.DataAtualizacao = DateTime.Now;
            return View(metodoApi);
        }

        // POST: MetodoApis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Metodo,DataCadastro,DataAtualizacao")] MetodoApi metodoApi)
        {
            if (id != metodoApi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    metodoApi.DataAtualizacao = DateTime.Now;
                    _context.Update(metodoApi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoApiExists(metodoApi.ID))
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
            return View(metodoApi);
        }

        // GET: MetodoApis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoApi = await _context.MetodoApi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (metodoApi == null)
            {
                return NotFound();
            }

            return View(metodoApi);
        }

        // POST: MetodoApis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoApi = await _context.MetodoApi.FindAsync(id);
            _context.MetodoApi.Remove(metodoApi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoApiExists(int id)
        {
            return _context.MetodoApi.Any(e => e.ID == id);
        }
    }
}
