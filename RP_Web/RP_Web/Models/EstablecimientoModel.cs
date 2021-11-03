using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_Web.Models
{
    public class EstaModel
    {
        public string LugarReservaId { get; set; }
        public string ClasificacionId { get; set; }
        public string NombreLugar { get; set; }
        public string Ubicacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Habilitado { get; set; }
    }
}