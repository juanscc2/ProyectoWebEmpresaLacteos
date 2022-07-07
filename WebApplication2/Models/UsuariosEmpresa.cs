using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UsuariosEmpresa
    {
        public int IdUsuario { get; set; }

        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CorreoElectronico { get; set; }
        public string NombreEmpresa { get; set; }

    }
}