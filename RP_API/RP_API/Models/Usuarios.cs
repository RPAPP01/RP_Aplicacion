using System;
using System.ComponentModel.DataAnnotations;

namespace RP_API.Models
{
    public class Usuarios
    {
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        [Key]
        public int PerfilId { get; set; }
        public string Uri { get; set; }
        public bool Habilitado { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

