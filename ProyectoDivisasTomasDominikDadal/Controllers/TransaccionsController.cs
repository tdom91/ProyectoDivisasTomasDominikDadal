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
    public class TransaccionsController : BaseController
    {
        private ITransaccionRepository repositorio = null;

        public TransaccionsController()
        {
            this.repositorio = new TransaccionRepository();

        }

        public TransaccionsController(ITransaccionRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: Transaccions
            public async Task<ActionResult> Index()
            {
                await repositorio.CargarApi();
                return View(await repositorio.GetAll());
            }

        // GET: Transaccions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = await repositorio.GetById(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,sku,amount,currency")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                repositorio.Insert(transaccion);
                await repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = await repositorio.GetById(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,sku,amount,currency")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                repositorio.Update(transaccion);
                await repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = await repositorio.GetById(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transaccion transaccion =  await repositorio.GetById(id);
            await repositorio.Delete(transaccion);
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
