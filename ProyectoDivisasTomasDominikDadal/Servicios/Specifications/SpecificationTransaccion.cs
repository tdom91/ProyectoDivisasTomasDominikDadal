using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoDivisasTomasDominikDadal.Models;

namespace ProyectoDivisasTomasDominikDadal.Servicios.Specifications
{
    public class SpecificationTransaccion : ITransaccionSpecification
    {
        public bool IsSatisfiedBy(Transaccion transaccion)
        {
            if (!transaccion.sku.Equals("") && !transaccion.amount.Equals("") && !transaccion.currency.Equals(""))
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