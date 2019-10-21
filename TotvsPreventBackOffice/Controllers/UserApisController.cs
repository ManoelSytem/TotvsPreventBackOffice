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
    public class UserApisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserApisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserApis
        public async Task<IActionResult> Index()
        {
            return RedirectToAction(nameof(Create));
        }

        // GET: UserApis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApi = await _context.UserApi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userApi == null)
            {
                return NotFound();
            }

            return View(userApi);
        }

        // GET: UserApis/Create
        public  IActionResult Create()
        {
            ViewBag.MetodosApi = _context.MetodoApi.ToList();
            ViewBag.Modulo = _context.Modulo.Select(e => new SelectListItem()
            { Text = e.descricao, Value = e.Id.ToString() }).ToList();
            return View();
        }

        // POST: UserApis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,User")] UserApi userApi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userApi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(userApi);
        }

        // GET: UserApis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApi = await _context.UserApi.FindAsync(id);
            if (userApi == null)
            {
                return NotFound();
            }
            return View(userApi);
        }

        // POST: UserApis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,User")] UserApi userApi)
        {
            if (id != userApi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userApi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserApiExists(userApi.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Create));
            }
            return View(userApi);
        }

        // GET: UserApis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApi = await _context.UserApi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userApi == null)
            {
                return NotFound();
            }

            return View(userApi);
        }

        // POST: UserApis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userApi = await _context.UserApi.FindAsync(id);
            _context.UserApi.Remove(userApi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
        }

        private bool UserApiExists(int id)
        {
            return _context.UserApi.Any(e => e.ID == id);
        }
    }
}
