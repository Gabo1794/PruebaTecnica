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
    public class LoginController : ControllerBase
    {
        private FacadeImplementation facade { get; set; }
        private readonly PruebaTecnicaContext _context;

        public LoginController(PruebaTecnicaContext context)
        {
            _context = context;
            facade = new FacadeImplementation(_context);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> IniciarSesion([FromBody] Login usuarioLogeado)
        {
            return await facade.ValidarInicioDeSesion(usuarioLogeado);
        }

    }
}