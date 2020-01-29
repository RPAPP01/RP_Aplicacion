using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using RP_API.Models;

namespace RP_API.Controllers
{
    [Route("[controller]")]
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
        //AddAuthors
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
    }
}