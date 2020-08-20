using Empresa.PruebaTecnica.Api.Contratos;
using Empresa.PruebaTecnica.Api.Dao.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Empresa.PruebaTecnica.Api.Dao
{
    public class DaoImplementation
    {
        private readonly PruebaTecnicaContext _context;
        private const string conection = "Server=localhost;Database=PruebaTecnica;User Id=sa;Password=sa;";

        public DaoImplementation(PruebaTecnicaContext context)
        {
            _context = context;
        }

        #region Usuario
        public ModeloUsuario ObtenerUsuarioPorId(Guid id)
        {
            Models.Usuarios modeloUsuario = _context.Usuarios.Find(id);

            ModeloUsuario usuario = new ModeloUsuario
            {
                Id = modeloUsuario.Id,
                Correo = modeloUsuario.Correo,
                Usuario = modeloUsuario.Usuario,
                Contrasena = modeloUsuario.Contrasena,
                Estatus = modeloUsuario.Estatus,
                Sexo = modeloUsuario.Sexo,
                FechaCreacion = modeloUsuario.FechaCreacion
            };

            return usuario;
        }

        public ModeloUsuario[] ObtenerUsuarios()
        {
            List<ModeloUsuario> usuarios = new List<ModeloUsuario>();
            
            using (SqlConnection con = new SqlConnection(conection))
            {

                SqlCommand sqlCommand = new SqlCommand("pa_obtenerUsuarios",con);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    ModeloUsuario usu = new ModeloUsuario();
                    usu.Id = new Guid(dr["Id"].ToString());
                    usu.Correo = dr["Correo"].ToString();
                    usu.Usuario = dr["Usuario"].ToString();
                    usu.Contrasena = dr["Contrasena"].ToString();
                    usu.Estatus = Convert.ToInt32(dr["Estatus"].ToString());
                    usu.Sexo = dr["Sexo"].ToString().ToLower() == "true" ? true : false;

                    usuarios.Add(usu);
                }
                con.Close();

            }

            return usuarios.ToArray();

        }

        public bool GuardarUsuario(ModeloUsuario usuario)
        {
            bool idValido = false;

            do {
                Guid nuevoGuid = Guid.NewGuid();
                Models.Usuarios usu = _context.Usuarios.Find(nuevoGuid);
                if (usu == null) idValido = true;

            } while (!idValido);
            

            Models.Usuarios nuevoUsuario = new Models.Usuarios
            {
                Id = Guid.NewGuid(),
                Correo = usuario.Correo,
                Usuario = usuario.Usuario,
                Contrasena = usuario.Contrasena,
                Estatus = usuario.Estatus,
                Sexo = usuario.Sexo,
                FechaCreacion = DateTime.Now
            };

            _context.Usuarios.Add(nuevoUsuario);

            if (_context.SaveChanges() > 0) return true;
            else return false;
        }

        public bool ActualizarUsuario(ModeloUsuario usuario)
        {
            Models.Usuarios usuarios = _context.Usuarios.Find(usuario.Id);

            usuarios.Usuario = usuario.Usuario;

            if (usuario.Contrasena != String.Empty)
                usuarios.Contrasena = usuario.Contrasena;

            usuarios.Sexo = usuario.Sexo;
            usuarios.Correo = usuario.Correo;

            if (_context.SaveChanges() > 0) return true;
            else return false;
        }

        public bool EliminarUsuario(Guid id)
        {
            Models.Usuarios usuario = _context.Usuarios.Find(id);

            if(usuario != null)
            {
                usuario.Estatus = usuario.Estatus == (int)EstatusUsuario.Activo ? 2 : 1;

                if (_context.SaveChanges() > 0) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Login
        public async Task<bool> ValidarInicioDeSesion(Login usuarioLogeado)
        {

            bool estatus = false;

            using (SqlConnection con = new SqlConnection(conection))
            {

                SqlCommand sqlCommand = new SqlCommand("pa_validarLogin", con);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@usuario", usuarioLogeado.UsuarioLogin);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuarioLogeado.ContrasenaLogin);

                con.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    estatus = dr["Login"].ToString().ToLower() == "true" ? true : false;
                }
                con.Close();

            }

            return estatus;
        }
        #endregion
    }
}
