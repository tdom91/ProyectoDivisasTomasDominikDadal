using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDivisasTomasDominikDadal.Models;
using ProyectoDivisasTomasDominikDadal.Servicios.Repositorio;

namespace ProyectoDivisasTomasDominikDadal.Tests
{
    class RepositoriosTest
    {
        [TestMethod]
        public void DivisasRepositoryTest()
        {
            var repositorio = new DivisaRepository();

            var lista = repositorio.table;

            Assert.IsNotNull(lista);
            Assert.AreEqual(repositorio.table.Count(), lista.Count());

            var nuevaDivisa = new Divisa()
            {
                from = "USD", 
                to = "EUR",
                rate = 1.2m
            };
            repositorio.Insert(nuevaDivisa);
            var aEncontrar = repositorio.GetById(nuevaDivisa.Id);
            Assert.AreEqual(nuevaDivisa.Id, aEncontrar.Id);
        }

        [TestMethod]
        public void TransaccionRepositoryTest()
        {
            var repositorio = new TransaccionRepository();

            var lista = repositorio.table;

            Assert.IsNotNull(lista);
            Assert.AreEqual(repositorio.table.Count(), lista.Count());
            
            var nuevaTransaccion = new Transaccion(){amount = "70", sku = "TH456", currency = "1.2" };
            repositorio.Insert(nuevaTransaccion);
            var aEncontrar = repositorio.GetById(nuevaTransaccion.Id);
            Assert.AreEqual(nuevaTransaccion.Id, aEncontrar.Id);
        }

    }
}
