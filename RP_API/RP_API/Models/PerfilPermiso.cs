using System;
namespace RP_API.Models
{
    public class PerfilPermiso
    {
        public int PerfilPermisoId { get; set; }
        public int PerfilId { get; set; }
        public int PermisoId { get; set; }
        public bool Habilitado { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
