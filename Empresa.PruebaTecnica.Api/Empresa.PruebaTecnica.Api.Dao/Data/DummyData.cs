using Empresa.PruebaTecnica.Api.Dao.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.PruebaTecnica.Api.Dao.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                PruebaTecnicaContext context = serviceScope.ServiceProvider.GetService<PruebaTecnicaContext>();
                context.Database.EnsureCreated();

                Usuarios[] usuarios = GetUsuarios(context).ToArray();
                context.Usuarios.AddRange(usuarios);
                context.SaveChanges();
            }
        }

        public static List<Usuarios> GetUsuarios(PruebaTecnicaContext db)
        {
            List<Usuarios> usuarios = new List<Usuarios>() {
                new Usuarios {
                Id = Guid.NewGuid(),
                Correo = "correo@correo.com",
                Usuario = "gabo1794",
                Contrasena = "Qo94v0JpPaL59LS6U3xfEB4nVgc=",
                Estatus = 1,
                Sexo = true,
                FechaCreacion = DateTime.Now
                },
                 new Usuarios {
                Id = Guid.NewGuid(),
                Correo = "correo1@correo.com",
                Usuario = "gabo1795",
                Contrasena = "Qo94v0JpPaL59LS6U3xfEB4nVgc=",
                Estatus = 1,
                Sexo = false,
                FechaCreacion = DateTime.Now
                },
                                new Usuarios {
                Id = Guid.NewGuid(),
                Correo = "correo2@correo.com",
                Usuario = "gabo1796",
                Contrasena = "Qo94v0JpPaL59LS6U3xfEB4nVgc=",
                Estatus = 2,
                Sexo = true,
                FechaCreacion = DateTime.Now
                }
            };
            return usuarios;
        }
    }
}
