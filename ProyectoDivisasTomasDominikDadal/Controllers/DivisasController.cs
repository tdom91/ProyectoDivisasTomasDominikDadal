using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoDivisasTomasDominikDadal.DAL;
using ProyectoDivisasTomasDominikDadal.Models;
using ProyectoDivisasTomasDominikDadal.Repositorio;
using ProyectoDivisasTomasDominikDadal.Servicios.Repositorio;

namespace ProyectoDivisasTomasDominikDadal.Controllers
{
    public class DivisasController : BaseController
    {
        private IDivisaRepository repositorio = null;

        public DivisasController()
        {
            this.repositorio = new DivisaRepository();

        }

        public DivisasController(IDivisaRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: Divisas
        public async Task<ActionResult> Index()
        {
            await repositorio.CargarApi();
            return View(await repositorio.GetAll());
        }

        // GET: Divisas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Divisa divisa = await repositorio.GetById(id);
            if (divisa == null)
            {
                return HttpNotFound();
            }
            return View(divisa);
        }

        // GET: Divisas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Divisas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,from,to,rate")] Divisa divisa)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(divisa);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(divisa);
        }

        // GET: Divisas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Divisa divisa = await repositorio.GetById(id);
            if (divisa == null)
            {
                return HttpNotFound();
            }
            return View(divisa);
        }

        // POST: Divisas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,from,to,rate")] Divisa divisa)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(divisa);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(divisa);
        }

        // GET: Divisas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Divisa divisa = await repositorio.GetById(id);
            if (divisa == null)
            {
                return HttpNotFound();
            }
            return View(divisa);
        }

        // POST: Divisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Divisa divisa = await repositorio.GetById(id);
            await repositorio.Delete(divisa);
            await repositorio.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
