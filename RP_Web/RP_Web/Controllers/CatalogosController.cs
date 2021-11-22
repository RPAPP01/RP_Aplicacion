using RP_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP_Web.Controllers
{
    public class CatalogosController : Controller
    {
        Configuracion_DB c = new Configuracion_DB();
        // GET: Catalogos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reservas()
        {
            return View(c.ListaReservas());
        }

        public ActionResult ReservasDatos()
        {
            return Json(c.ListaReservas());
        }

        public ActionResult Mesas()
        {
            return View(c.ListaMesas());
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult MesaUpdate(string Query,int IDMesa,string Lugar,string Descripcion) 
        {
            return Json(c.MesaUpdate(Query, IDMesa, Lugar, Descripcion));
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult MesaInsert(string Query, int IDMesa, string Lugar, string Descripcion)
        {
            return Json(c.MesaInsert(Query, IDMesa, Lugar, Descripcion));
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult EstablecimientoInsert(string Query, int LugarReservaId, string ClasificacionId, string NombreLugar, string Ubicacion, string Telefono, string Correo, string Habilitado)
        {
            return Json(c.EstablecimientoInsert(Query, LugarReservaId, ClasificacionId, NombreLugar,Ubicacion,Telefono,Correo,Habilitado));
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult EstablecimientoUpdate(string Query, int LugarReservaId, string ClasificacionId, string NombreLugar, string Ubicacion, string Telefono, string Correo, string Habilitado)
        {
            return Json(c.EstablecimientoUpdate(Query, LugarReservaId, ClasificacionId, NombreLugar, Ubicacion, Telefono, Correo, Habilitado));
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult AreaUpdate(string Query, int AreaId, string Descripcion, string Habilitado)
        {
            return Json(c.AreaUpdate(Query, AreaId, Descripcion, Habilitado));
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult AreaInsert(string Query, int AreaId, string Descripcion, string Habilitado)
        {
            return Json(c.AreaInsert(Query, AreaId, Descripcion, Habilitado)); //Cuando se insertan datos es necesario que sean de tipos JSON
        }

        public ActionResult Clasificacion()
        {
            return View(c.ListaClasificacion());
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult ClasificacionUpdate(string Query, int ClasificacionId, string Descripcion, int Habilitado)
        {
            return Json(c.ClasificacionUpdate(Query, ClasificacionId, Descripcion, Habilitado));
        }

        [HttpPost]//Mandar datos tipo json 
        public ActionResult ClasificacionInsert(string Query, int ClasificacionId, string Descripcion, int Habilitado)
        {
            return Json(c.ClasificacionInsert(Query, ClasificacionId, Descripcion, Habilitado)); //Cuando se insertan datos es necesario que sean de tipos JSON
        }

        public ActionResult Establecimiento()
        {
            return View(c.ListaEstablecimiento());
        }



        [HttpPost]
        public ActionResult Select_Establecimiento()
        {
            return Json(c.ListaEstablecimiento());
        }

        [HttpPost]
        public ActionResult Select_Area()
        {
            return Json(c.ListaEstablecimiento());
        }

        [HttpPost]
        public ActionResult Select_Clasificacion()
        {
            return Json(c.ListaClasificacion());
        }

        public ActionResult Area()
        {
            return View(c.ListaArea());
        }
    }
}
