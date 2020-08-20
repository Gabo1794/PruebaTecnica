using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Empresa.PruebaTecnica.Api.Dao.Models
{
    public class Usuarios
    {
        public Guid Id { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Estatus { get; set; }
        public bool Sexo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
