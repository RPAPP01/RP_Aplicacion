using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RP_API.Models;

namespace RP_API.Controllers
{
    [Route("api/v1/[controller]")]
    public class PermisoController : Controller
    {
        private readonly LibraryDbContext _context;

        public PermisoController(LibraryDbContext context)
        {
            _context = context;
        }
        //GET
        [HttpGet]
        public List<Permiso> GetPermiso()
        {
            return _context.Permiso.ToList();

        }
        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetPermisoById(int id)
        {

            var permiso = this._context.Permiso.SingleOrDefault(ct => ct.PermisoId == id);
            if (permiso != null)
            {
                return Ok(permiso);
            }
            else
            {
                return NotFound();
            }

        }
        //AddPerfil
        [HttpPost]
        public IActionResult AddPermiso([FromBody] Permiso permiso)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Permiso.Add(permiso);
            this._context.SaveChanges();
            return Created($"Permiso/{permiso.PermisoId}", permiso);
        }
        //PutPermiso
        [HttpPut("{id}")]
        public IActionResult PutPermiso(int id, [FromBody] Permiso permiso)
        {
            var target = _context.Permiso.FirstOrDefault(ct => ct.PermisoId == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.Descripcion = permiso.Descripcion;
                target.Habilitado = permiso.Habilitado;
                target.Updated = permiso.Updated;

                _context.Permiso.Update(target);
                _context.SaveChanges();
                return Ok();
            }
        }

        //Delete Permiso
        [HttpDelete("{id}")]
        public IActionResult DeletePermiso(int id)
        {
            var target = _context.Permiso.FirstOrDefault(ct => ct.PermisoId == id);
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Permiso.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}