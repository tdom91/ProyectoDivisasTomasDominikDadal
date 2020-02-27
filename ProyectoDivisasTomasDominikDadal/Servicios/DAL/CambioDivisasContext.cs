using ProyectoDivisasTomasDominikDadal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectoDivisasTomasDominikDadal.DAL
{
    public class CambioDivisasContext:DbContext
    {
        public CambioDivisasContext() : base("CambioDivisasContext")
        { }

        public DbSet<Divisa> Divisas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ProyectoDivisasTomasDominikDadal.Models.VMSku> VMSkus { get; set; }
    }
}