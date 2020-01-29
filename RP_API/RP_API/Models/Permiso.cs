using System;
namespace RP_API.Models
{
    public class Permiso
    {
        public int PermisoId { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
