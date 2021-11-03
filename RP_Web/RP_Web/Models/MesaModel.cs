using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP_Web.Models
{
    public class MesaModel
    {
        public string MesaId { get; set; }
        public string LugarReservaId { get; set; }
        public string Descripcion { get; set; }
    }

    public class MesaInUp
    {
        public string MesaId;
    }
}