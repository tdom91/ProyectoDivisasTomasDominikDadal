using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDivisasTomasDominikDadal.Models;
using ProyectoDivisasTomasDominikDadal.Servicios.Repositorio;

namespace ProyectoDivisasTomasDominikDadal.Repositorio
{
    public interface ITransaccionRepository: IGenericRepository<Transaccion>
    {
         List<VMSku> AgruparSkusYSumar();
         List<VMSku> AgruparSkus(string sku);
    }
}
