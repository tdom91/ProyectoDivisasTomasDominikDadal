using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDivisasTomasDominikDadal.Servicios.Repositorio
{
    public interface IGenericRepository<T> where T : class
    {
        Task CargarApi();
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(object id);
        Task Save();
    }
}
