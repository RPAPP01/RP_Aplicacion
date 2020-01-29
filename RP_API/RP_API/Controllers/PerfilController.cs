using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using RP_API.Models;

namespace RP_API.Controllers
{
    [Route("api/v1/[controller]")]
    public class PerfilController : Controller
    {
        private readonly LibraryDbContext _context;

        public PerfilController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Perfil>Get()
        {
            return _context.Perfil.ToList();

        }

        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetPerfilById(int id)
        {

            var perfil = this._context.Perfil.SingleOrDefault(ct => ct.PerfilId == id);
            if (perfil != null)
            {
                return Ok(perfil);
            }
            else
            {
                return NotFound();
            }

        }
        //AddPerfil
        [HttpPost]
        public IActionResult AddPerfil([FromBody] Perfil perfil)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Perfil.Add(perfil);
            this._context.SaveChanges();
            return Created($"Perfil/{perfil.PerfilId}", perfil);
        }
        //PutPerfil
        [HttpPut("{id}")]
        public IActionResult PutPerfil(int id, [FromBody] Perfil perfil)
        {
            var target = _context.Perfil.FirstOrDefault(ct => ct.PerfilId == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.Descripcion = perfil.Descripcion;
                target.Habilitado = perfil.Habilitado;
                target.Updated = perfil.Updated;

                _context.Perfil.Update(target);
                _context.SaveChanges();
                return Ok();
            }
        }

        //Delete Perfil
        [HttpDelete("{id}")]
        public IActionResult DeletePerfil(int id)
        {
            var target = _context.Perfil.FirstOrDefault(ct => ct.PerfilId == id);
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Perfil.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }


    }
}