using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoDivisasTomasDominikDadal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProyectoDivisasTomasDominikDadal.Tests
{
    [TestClass]
    class ControladoresTest
    {
        

        [TestMethod]
        public async Task DivisaControllerTest()
        {

            DivisasController controller = new DivisasController();

            ViewResult result =  await controller.Index() as ViewResult;

            
            Assert.IsNotNull(result);
        }

        public async Task TransaccionController()
        {
            TransaccionsController controller = new TransaccionsController();
            ViewResult result = await controller.Index() as ViewResult;


            Assert.IsNotNull(result);
        }

        public void ConsultasController()
        {
            ConsultasController controller = new ConsultasController();
            ViewResult result = controller.Consulta1("O9742") as ViewResult;


            Assert.IsNotNull(result);
        }
        
    }
}
