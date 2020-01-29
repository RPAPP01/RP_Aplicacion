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
    public class UsuariosController : Controller
    {
        private readonly LibraryDbContext _context;

        public UsuariosController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Usuarios> GetUsuario()
        {
            return _context.Usuarios.ToList();

        }

        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetUsuariosById(int id)
        {

            var usuarios = this._context.Usuarios.SingleOrDefault(ct => ct.UserId == id);
            if (usuarios != null)
            {
                return Ok(usuarios);
            }
            else
            {
                return NotFound();
            }

        }
        //AddPerfilPermiso
        [HttpPost]
        public IActionResult AddUsuarios([FromBody] Usuarios usuarios)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Usuarios.Add(usuarios);
            this._context.SaveChanges();
            return Created($"Usuarios/{usuarios.UserId}", usuarios);
        }
        //PutUsuarios
        [HttpPut("{id}")]
        public IActionResult PutUsuarios(int id, [FromBody] Usuarios usuarios)
        {
            var target = _context.Usuarios.FirstOrDefault(ct => ct.UserId == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.UserId = usuarios.UserId;
                target.Nombre = usuarios.Nombre;
                target.Pass = usuarios.Pass;
                target.Correo = usuarios.Correo;
                target.Celular = usuarios.Celular;
                target.PerfilId = usuarios.PerfilId;
                target.Uri = usuarios.Uri; 
                target.Habilitado = usuarios.Habilitado;
                target.Updated = usuarios.Updated;

                _context.Usuarios.Update(target);
                _context.SaveChanges();
                return Ok();
            }
        }

        //Delete Usuarios
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuarios(int id)
        {
            var target = _context.Usuarios.FirstOrDefault(ct => ct.UserId == id);
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Usuarios.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}