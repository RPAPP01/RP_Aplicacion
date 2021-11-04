using System.ComponentModel.DataAnnotations;
using System.Web;


namespace RP_Web.Models
{

    public class UsuarioPermisosModel
    {
        public string Nombre_usuario { get; set; }
        public string Email { get; set; }
        public string Roll { get; set; }
        public string Permisos { get; set; }
    }
    public class UsuarioInfo
    {
        public string Nombre_usuario { get; set; }
        public string Email { get; set; }
        public string Passwords { get; set; }
        public string Permisos { get; set; }
        public string Userliss { get; set; }
    }
    public class CorreoModel
    {
        [Required, Display(Name = "Correo Destinatario"), EmailAddress]
        public string Para { get; set; }
        [Required]
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public HttpPostedFileBase Adjunto { get; set; }
        [Required]
        [Display(Name = "Correo Remitente"), EmailAddress]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
    }


    //Datos de nuevo usuario
    public class NuevoUsuario
    {
        public string Nombre_usuario { get; set; } //Parametros que almacena el Model
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Passwords { get; set; }
    }

    //Reservacion
    public class Reservacion
    {
        public string Nombre_reserva { get; set; }
        public string Lugar { get; set; }
        public string Personas { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }
    }
}