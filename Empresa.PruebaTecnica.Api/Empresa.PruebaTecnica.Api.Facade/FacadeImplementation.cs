using Empresa.PruebaTecnica.Api.Contratos;
using Empresa.PruebaTecnica.Api.Dao;
using Empresa.PruebaTecnica.Api.Dao.Data;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.PruebaTecnica.Api.Facade
{
    public class FacadeImplementation
    {
        private DaoImplementation dao { get; set; }
        private readonly PruebaTecnicaContext _context;

        public FacadeImplementation(PruebaTecnicaContext context)
        {
            _context = context;
            dao = new DaoImplementation(_context);
        }

        #region Usuarios
        public ModeloUsuario ObtenerUsuarioPorId(Guid id)
        {
            return dao.ObtenerUsuarioPorId(id);
        }

        public ModeloUsuario[] ObtenerUsuarios()
        {
            return dao.ObtenerUsuarios();
        }

        public bool GuardarUsuario(ModeloUsuario usuario)
        {
            if(usuario.Contrasena != String.Empty)
            {
                string contrasenaEncriptada = EncriptarContrasenaBase64(usuario.Contrasena);
                usuario.Contrasena = contrasenaEncriptada;
            }
            
            if (usuario.Id == null)
            {
                return dao.GuardarUsuario(usuario);
            }
            else
            {
                return ActualizarUsuario(usuario);
            }
            

        }

        public bool EliminarUsuario(Guid id)
        {
            return dao.EliminarUsuario(id);
        }
        #endregion

        #region Login
        public async Task<bool> ValidarInicioDeSesion(Login usuarioLogeado)
        {
            usuarioLogeado.ContrasenaLogin = EncriptarContrasenaBase64(usuarioLogeado.ContrasenaLogin);

            return await dao.ValidarInicioDeSesion(usuarioLogeado);
        }
        #endregion

        #region Funciones privadas
        private bool ActualizarUsuario(ModeloUsuario usuario)
        {
            return dao.ActualizarUsuario(usuario);
        }

        private string EncriptarContrasenaBase64(string contrasena)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(contrasena);
            byte[] enArreglo = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(enArreglo);
        }
        #endregion
    }
}
