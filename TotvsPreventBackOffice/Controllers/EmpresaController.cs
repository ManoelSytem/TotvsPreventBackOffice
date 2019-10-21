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
    public class EmpresaController : Controller
    {
        private ApplicationDbContext _db;

        public EmpresaController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: Empresa
        
        public ActionResult Index()
        {

            return View(_db.Empresa.ToList());
        }

        // GET: Empresa/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var empresa = _db.Empresa.Find(id);
            return View(empresa);
        }

        // GET: Empresa/Create
        [HttpGet]
        public ActionResult Create()
        {
            

            Empresa empresa = new Empresa();
            empresa.DataCadastro = DateTime.Now;
            empresa.DataAtualizacao = DateTime.Now;
            return View(empresa);
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  
                    empresa.DataCadastro = DateTime.Now;
                    empresa.DataAtualizacao = DateTime.Now;
                    _db.Empresa.Add(empresa);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empresa = _db.Empresa.Find(id);
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empresa empresaNew)
        {
            try
            {
                // TODO: Add update logic here
                empresaNew.DataAtualizacao = DateTime.Now;
                _db.Entry(empresaNew).State = EntityState.Modified;

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}