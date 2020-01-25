using System;
namespace RP_API.Models
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
