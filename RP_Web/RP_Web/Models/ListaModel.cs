using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace RP_Web.Models
{
    public class ListModel
    {
        public List<UsuarioPermisosModel> Upm = new List<UsuarioPermisosModel>();
        public List<MesaModel> ListMesa = new List<MesaModel>();
        public List<AreaModel> ListArea = new List<AreaModel>();
        public List<ClasModel> ListClas = new List<ClasModel>();
        public List<EstaModel> ListEsta = new List<EstaModel>();
        public List<ReservaModel> ListReserva = new List<ReservaModel>();
    }

}