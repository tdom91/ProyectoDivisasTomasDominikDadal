using ProyectoDivisasTomasDominikDadal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDivisasTomasDominikDadal.Servicios.Specifications
{
    interface ITransaccionSpecification
    {
        bool IsSatisfiedBy(Transaccion transaccion);
    }
}
