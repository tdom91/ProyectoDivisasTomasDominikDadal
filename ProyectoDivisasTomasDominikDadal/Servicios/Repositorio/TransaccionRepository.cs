using ProyectoDivisasTomasDominikDadal.Models;
using ProyectoDivisasTomasDominikDadal.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using ProyectoDivisasTomasDominikDadal.JSonConverterService;
using ProyectoDivisasTomasDominikDadal.Servicios.JSonConverterService;
using ProyectoDivisasTomasDominikDadal.Servicios.Specifications;
using ProyectoDivisasTomasDominikDadal.TransversarInfraestructure;

namespace ProyectoDivisasTomasDominikDadal.Servicios.Repositorio
{
    public class TransaccionRepository : GenericRepository<Transaccion>, ITransaccionRepository
    {
        IJsonConverter<Transaccion> conversor = new TransaccionJsonConverter();
        ITransaccionSpecification specificacion = new SpecificationTransaccion();
        public override async Task CargarApi()
        {
            try
            {
                table.RemoveRange(table);
                var listaTransacciones =
                    conversor.ImportJson("http://quiet-stone-2094.herokuapp.com/transactions.json");
                var listaComprobada = new List<Transaccion>();

                foreach (var x in listaTransacciones)
                {
                    if (specificacion.IsSatisfiedBy(x))
                    {
                        listaComprobada.Add(x);
                    }
                    
                }
                table.AddRange(listaComprobada);
                await _context.SaveChangesAsync();
            }
            catch (HttpException)
            {
            }
            catch (Exception ex)
            {
                throw new TransaccionRepositoryServiceException("Error en Transaccion Repository", ex);
            }
        }

        public List<VMSku> AgruparSkus(string sku)
        {
            var query = from t in _context.Transacciones where t.sku == sku select t;
            var listaSku = new List<VMSku>();

            foreach (var q in query)
            {
              var NuevoVMSku = new VMSku();
              NuevoVMSku.Sku = q.sku;
              NuevoVMSku.Amount = q.amount;
              NuevoVMSku.Currency = q.sku;
              listaSku.Add(NuevoVMSku);
            }

            return listaSku;
        }

        public List<VMSku> AgruparSkusYSumar()
        {
            var listaSumaSkus = new List<VMSku>();
            var query2 = from t in _context.Transacciones
                group t by t.sku
                into grupoSku
                select new
                {
                    nombre = grupoSku.Key,
                    montoTotal = grupoSku.Sum(x => Decimal.Parse(x.amount)),
                    
                    
                };

            foreach (var x in query2)
            {
                var nuevoVMSku = new VMSku();
                nuevoVMSku.Sku = x.nombre;
                nuevoVMSku.Amount = x.montoTotal.ToString();
                
            }

        }







    }
    }