using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDivisasTomasDominikDadal.Models;

namespace ProyectoDivisasTomasDominikDadal.Servicios.Specifications
{
    interface IDivisaSpecification
    {
        bool IsSatisfiedBy(Divisa divisa);
    }
}
