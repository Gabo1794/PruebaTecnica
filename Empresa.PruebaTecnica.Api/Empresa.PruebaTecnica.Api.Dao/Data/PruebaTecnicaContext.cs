using Empresa.PruebaTecnica.Api.Dao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.PruebaTecnica.Api.Dao.Data
{
    public class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }

    //class PruebaTecnicaContext<T> : DbContext where T : class
    //{
    //    public PruebaTecnicaContext(DbContextOptions options) : base(options) { }
    //    public PruebaTecnicaContext() : base() { }
    //    public DbSet<T> DbSet { get; set; }
    //}


    //public class PruebaTecnica<T> where T : class
    //{
    //    protected T ObtenerPorId(Guid Id)
    //    {
    //        using (PruebaTecnicaContext<T> context = new PruebaTecnicaContext<T>())
    //        {
    //            return context.DbSet.Find(Id);
    //        }
    //    }
    //}
}
