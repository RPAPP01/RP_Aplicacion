using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using RP_API.Models;


namespace RP_API.Models
{
    [Route("api/v1/[controller]")]
    public class PerfilPermisoController : Controller
    {
        private readonly LibraryDbContext _context;

        public PerfilPermisoController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<PerfilPermiso> GetPerfilPermiso()
        {
            return _context.PerfilPermiso.ToList();

        }

        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetPerfilPermisoById(int id)
        {

            var perfilpermiso = this._context.PerfilPermiso.SingleOrDefault(ct => ct.PerfilPermisoId == id);
            if (perfilpermiso != null)
            {
                return Ok(perfilpermiso);
            }
            else
            {
                return NotFound();
            }

        }
        //AddPerfilPermiso
        [HttpPost]
        public IActionResult AddPerfilPermiso([FromBody] PerfilPermiso perfilpermiso)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.PerfilPermiso.Add(perfilpermiso);
            this._context.SaveChanges();
            return Created($"PerfilPermiso/{perfilpermiso.PerfilPermisoId}", perfilpermiso);
        }
        //Putperfilpermiso
        [HttpPut("{id}")]
        public IActionResult PutPerfilPermiso(int id, [FromBody] PerfilPermiso perfilpermiso)
        {
            var target = _context.PerfilPermiso.FirstOrDefault(ct => ct.PerfilPermisoId == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.PerfilId = perfilpermiso.PerfilId;
                target.PermisoId = perfilpermiso.PermisoId;
                target.Habilitado = perfilpermiso.Habilitado;
                target.Updated = perfilpermiso.Updated;

                _context.PerfilPermiso.Update(target);
                _context.SaveChanges();
                return Ok();
            }
        }

        //Delete PerfilPermiso
        [HttpDelete("{id}")]
        public IActionResult DeletePerfilPermiso(int id)
        {
            var target = _context.PerfilPermiso.FirstOrDefault(ct => ct.PerfilId == id);
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.PerfilPermiso.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}