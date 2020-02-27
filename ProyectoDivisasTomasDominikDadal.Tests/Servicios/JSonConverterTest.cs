using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDivisasTomasDominikDadal.Servicios.JSonConverterService;

namespace ProyectoDivisasTomasDominikDadal.Tests
{
    [TestClass]
    class JSonConverterTest
    {
        [TestMethod]
        public void ObtenerJsonTransaccionTest()
        {
            var conversor = new TransaccionJsonConverter();

            var lista = conversor.ImportJson("http://quiet-stone-2094.herokuapp.com/transactions.json");

            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void ObtenerJsonDivisasTest()
        {
            var conversor = new DivisasJsonConverter();

            var lista = conversor.ImportJson("http://quiet-stone-2094.herokuapp.com/rates.json");

            Assert.IsNotNull(lista);
        }
    }
}
