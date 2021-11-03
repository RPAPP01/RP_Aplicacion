using RP_Web.Helper;
using RP_Web.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace RP_Web.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Email()
        {
            return View();
        }

        
        public ActionResult calendar()
        {
            return View();
        }

        public ActionResult IndexQR()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }


}
