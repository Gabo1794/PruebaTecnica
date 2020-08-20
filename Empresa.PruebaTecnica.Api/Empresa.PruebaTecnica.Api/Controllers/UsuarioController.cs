using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa.PruebaTecnica.Api.Contratos;
using Empresa.PruebaTecnica.Api.Dao.Data;
using Empresa.PruebaTecnica.Api.Facade;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PruebaTecnica")]
    public class UsuarioController : ControllerBase
    {
        private FacadeImplementation facade { get; set; }
        private readonly PruebaTecnicaContext _context;

        public UsuarioController(PruebaTecnicaContext context)
        {
            _context = context;
            facade = new FacadeImplementation(_context);
        }

        [HttpGet("{id}")]
        public ActionResult<ModeloUsuario> ObtenerUsuarioPorId(Guid id)
        {
            ModeloUsuario usuario = facade.ObtenerUsuarioPorId(id);

            return usuario;
        }

        [HttpGet]
        public ActionResult<ModeloUsuario[]> ObtenerUsuarios()
        {

            ModeloUsuario[] usuarios = facade.ObtenerUsuarios();

            return usuarios;
        }

        [HttpPost]
        public ActionResult<bool> GuardarUsuario([FromBody] ModeloUsuario usuario)
        {
            return facade.GuardarUsuario(usuario);
        }

        [HttpPut]
        public ActionResult<bool> EditarUsuario([FromBody] ModeloUsuario usuario)
        {
            return ActualizarUsuario(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> EliminarUsuario( Guid id)
        {
            return facade.EliminarUsuario(id);
        }

        private bool ActualizarUsuario(ModeloUsuario usuario)
        {
            return facade.GuardarUsuario(usuario);
        }

    }
}