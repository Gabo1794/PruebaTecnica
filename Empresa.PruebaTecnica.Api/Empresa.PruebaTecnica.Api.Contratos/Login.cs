using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Empresa.PruebaTecnica.Api.Contratos
{
    [DataContract]
    public class Login
    {
        [DataMember]
        public string UsuarioLogin { get; set; }
        [DataMember]
        public string ContrasenaLogin { get; set; }

    }
}
