using ProyectoDivisasTomasDominikDadal.Models;
using ProyectoDivisasTomasDominikDadal.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProyectoDivisasTomasDominikDadal.JSonConverterService;
using ProyectoDivisasTomasDominikDadal.Servicios.JSonConverterService;
using ProyectoDivisasTomasDominikDadal.Servicios.Specifications;
using ProyectoDivisasTomasDominikDadal.TransversarInfraestructure;

namespace ProyectoDivisasTomasDominikDadal.Servicios.Repositorio
{
    public class DivisaRepository : GenericRepository<Divisa>, IDivisaRepository
    {
        public override async Task CargarApi()
        {
          
            IJsonConverter<Divisa> conversor = new DivisasJsonConverter();
            IDivisaSpecification specificacion = new SpecificationDivisa();
            try
            {

                var listaDivisas = conversor.ImportJson("http://quiet-stone-2094.herokuapp.com/rates.json");
                var listaComprobada = new List<Divisa>();
                table.RemoveRange(table);

                foreach (var x in listaDivisas)
                {
                    if (specificacion.IsSatisfiedBy(x))
                    {
                        listaComprobada.Add(x);
                    }
                }
                table.AddRange(listaComprobada);
                await _context.SaveChangesAsync();
            }
            catch(HttpException)
            {
            }

            catch (Exception ex)
            {
                throw new DivisasRepositoryException("Error en  Divisas Repository", ex);
            }
        }
    }
}