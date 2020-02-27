using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoDivisasTomasDominikDadal.Models;

namespace ProyectoDivisasTomasDominikDadal.Servicios.Specifications
{
    public class SpecificationDivisa : IDivisaSpecification
    {
        public bool IsSatisfiedBy(Divisa divisa)
        {
            if (!divisa.from.Equals("") && !divisa.to.Equals("") && !divisa.rate.Equals(""))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}