using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoDivisasTomasDominikDadal.Repositorio;
using ProyectoDivisasTomasDominikDadal.Servicios.Repositorio;

namespace ProyectoDivisasTomasDominikDadal.Controllers
{
    public class ConsultasController : BaseController
    {

        ITransaccionRepository repositorio = null;
        public ConsultasController()
        {
            this.repositorio = new TransaccionRepository();

        }

        public ConsultasController(ITransaccionRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: Consultas
        public ActionResult Index()
        {
            repositorio.CargarApi();
            return View(repositorio.GetAll());
        }

        public ActionResult Consulta1(string id)
        {
            return View(repositorio.AgruparSkus(id));
        }
    }
}