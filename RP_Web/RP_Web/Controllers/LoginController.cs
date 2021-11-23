using RP_Web.Helper;
using RP_Web.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace RP_Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Configuracion_DB conex = new Configuracion_DB();
            bool cn = conex.conexion();
            if (cn == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult registro()
        {
            return View();
        }

        //Index mensaje de credenciales incorrectas
        public ActionResult IndexError()
        {
            Configuracion_DB conex = new Configuracion_DB();
            bool cn = conex.conexion();
            if (cn == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult ValidaLogin(string user, string pass)
        {
            Configuracion_DB c = new Configuracion_DB();
            return Json(c.ValidarLogin(user, pass));

        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult RegistroUsuarios(string user, string email, string cel, string pass)
        {
            Configuracion_DB c = new Configuracion_DB();
            return Json(c.RegistroUsuarios(user, email, cel, pass));

        }

        //Mandar los datos de la reservacion
        [HttpPost]//Mandar datos tipo json 
        public ActionResult NuevaReservacion(string nombre,  string personas, string hora, string fecha)
        {
            Configuracion_DB c = new Configuracion_DB();
            return Json(c.NuevaReservacion(nombre, personas, hora, fecha));

        }

        [HttpGet] //Recuperar Contraseña por correo
        public ActionResult RecuperaCredenciales(String usuario_correo)
        {
            Configuracion_DB c = new Configuracion_DB();
            var data = c.RecuperaCredenciales(usuario_correo);
            if (data.Count > 0)
            {
                CorreoModel movie = new CorreoModel();
                movie.Para = data.First().Email;
                movie.Asunto = "Recuperar Credenciales RP.";
                movie.Cuerpo = @"
<body style='background-color:#292929'>

    <h2 style='font-family:'Georgia';  '>  </h2>

    <table style='background-color:#292929; margin: 0 auto;'>
        <tr>
            <td style='text-align:center; color:#ffffff; font-size:30px'> Hola, solicitaste la recuperacion de tus credenciales</td>
        </tr>
        <tr>
            <td><hr><br></td>
        </tr>
        <tr>
            <td style='text-align:center; color:#ffffff; font-size:20px'> Correo: " + data.First().Email + @" </td>
        </tr>
        <tr>
            <td style='text-align:center; color:#ffffff; font-size:20px'> Password: " + data.First().Passwords + @" </td>
        </tr>
        <tr>
            <td style='text-align:center;color:#ffffff; font-size:15px'> <h3>Si no solicitaste la recuperacion de tu credenciales <br> haz caso omiso a este correo.</h3></td>
        </tr>
        <tr>
            <td> <p style='text-align:center'><a href='http://devrpr-001-site1.itempurl.com/Home/Index'> <input type='image' src='http://devrpr-001-site1.itempurl.com/Images/RP_Logos.jpg' width='190' onclick='regresar()'></a></p> </td>
        </tr>
        <tr>
            <td style='text-align:center; color:#ffffff; font-size:10px'> &copy; RP Reservations. Derechos Reservados 2021 </td>
        </tr>
    </table>
       <script type='text/javascript'>
    function regresar()
                {
                    window.location = 'http://devrpr-001-site1.itempurl.com'; 
                }
    </ script >
</body>
</html>";
                movie.Correo = "luisdiegorodriguezgonzalez@gmail.com";
                movie.Pass = "ROGL990219";
                Email(movie);
                return Json(new { valido = true, mensaje = "Se envio un correo a su cuenta " + data.First().Email + " con las credenciales" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { valido = false, mensaje = "La cuenta de correo no esta registrada." }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Email(CorreoModel model)
        {
            if (ModelState.IsValid)
            {
                using (MailMessage mm = new MailMessage(model.Correo, model.Para))
                {
                    mm.Subject = model.Asunto;
                    mm.Body = model.Cuerpo;
                    //if (model.Adjunto.ContentLength > 0 && model.Adjunto != null)
                    //{
                    //    string fileName = Path.GetFileName(model.Adjunto.FileName);
                    //    mm.Attachments.Add(new Attachment(model.Adjunto.InputStream, fileName));
                    //}
                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(model.Correo, model.Pass);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        mm.Dispose();
                        smtp.Dispose();
                        return RedirectToAction("Sent");
                    }
                }
            }
            return View();
        }
    }

}
