using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TotvsPreventBackOffice.Data;
using TotvsPreventBackOffice.Models;
using TotvsPreventBackOffice.ViewModel;

namespace TotvsPreventBackOffice.Controllers
{
    public class UserModuloPerfilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserModuloPerfilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserModuloPerfils
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserModuloPerfil.ToListAsync());
        }

        // GET: UserModuloPerfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModuloPerfil = await _context.UserModuloPerfil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModuloPerfil == null)
            {
                return NotFound();
            }

            return View(userModuloPerfil);
        }

        // GET: UserModuloPerfils/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Modulo = _context.Modulo.Select(e => new SelectListItem()
            { Text = e.descricao, Value = e.Id.ToString() }).ToList();
            ViewBag.Usuario = _context.Users.Select(e => new SelectListItem()
            { Text = e.UserName, Value = e.Id }).ToList();
            return View();
        }

        // POST: UserModuloPerfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        public JsonResult Create(string IdUser, string IdModulo)
        {
            try
            {
                UserModuloPerfil novo = new UserModuloPerfil();
                novo.IdUser = IdUser;
                novo.CodModulo = Convert.ToInt32(IdModulo);
                _context.Add(novo);
                _context.SaveChangesAsync();
                return Json(new { sucesso = "Marcação excluída com sucesso!" });
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

        // GET: UserModuloPerfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModuloPerfil = await _context.UserModuloPerfil.FindAsync(id);
            if (userModuloPerfil == null)
            {
                return NotFound();
            }
            return View(userModuloPerfil);
        }

        // POST: UserModuloPerfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,CodModulo")] UserModuloPerfil userModuloPerfil)
        {
            if (id != userModuloPerfil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModuloPerfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModuloPerfilExists(userModuloPerfil.Id))
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
            return View(userModuloPerfil);
        }

        // GET: UserModuloPerfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModuloPerfil = await _context.UserModuloPerfil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModuloPerfil == null)
            {
                return NotFound();
            }

            return View(userModuloPerfil);
        }

        // POST: UserModuloPerfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModuloPerfil = await _context.UserModuloPerfil.FindAsync(id);
            _context.UserModuloPerfil.Remove(userModuloPerfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModuloPerfilExists(int id)
        {
            return _context.UserModuloPerfil.Any(e => e.Id == id);
        }
    }
}
