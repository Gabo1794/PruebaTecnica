using System;
using System.Runtime.Serialization;

namespace Empresa.PruebaTecnica.Api.Contratos
{
    [DataContract]
    public class ModeloUsuario
    {
        [DataMember]
        public Guid? Id { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Contrasena { get; set; }
        [DataMember]
        public int Estatus { get; set; }
        [DataMember]
        public bool Sexo { get; set; }
        [DataMember]
        public DateTime? FechaCreacion { get; set; }
    }
}
