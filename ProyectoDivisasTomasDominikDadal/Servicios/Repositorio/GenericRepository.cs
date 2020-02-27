using ProyectoDivisasTomasDominikDadal.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProyectoDivisasTomasDominikDadal.JSonConverterService;
using ProyectoDivisasTomasDominikDadal.Servicios.Repositorio;

namespace ProyectoDivisasTomasDominikDadal.Repositorio
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public CambioDivisasContext _context = null;
        public DbSet<T> table = null;
       

        public GenericRepository()
        {
            this._context = new CambioDivisasContext();
            table = _context.Set<T>();
            
        }

        public GenericRepository(CambioDivisasContext context)
        {
            this._context = context;
            table = _context.Set<T>();
           
        }

     

        public abstract Task CargarApi();
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}