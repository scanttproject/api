using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using sca.Models;
using Microsoft.EntityFrameworkCore;
using sca.Services;
using sca.Interfaces;

namespace sca.Controllers
{
		[ApiController]
	[Route("api/[controller]")]
	public class UsuariosController : Controller
	{
		private ITokenService tokenService;
		private SCADB db;
		public UsuariosController(SCADB database, ITokenService tokenService)		{
			this.db = database;
            this.tokenService = tokenService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> Get()
        {
            return Ok(db.Usuarios.ToList());
        }

        [HttpPost]
		public ActionResult Post([FromBody]Usuarios json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");
				json.contrasenia = BCrypt.Net.BCrypt.HashPassword(json.contrasenia);
				db.Usuarios.Add(json);
				db.SaveChanges();
			return Ok();
		}

        [HttpPost]
		[Route("[action]")]
        public async Task<ActionResult> Login([FromBody] Usuarios json)
        {
           if(json.nombreusuario == null || json.contrasenia == null)
			{
                return BadRequest("Usuario y/o contraseña incorrectos");
            }

			var user = await db.Usuarios.Where(u => u.nombreusuario == json.nombreusuario).FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest("Usuario y/o contraseña incorrectos");
            }

			var verify = BCrypt.Net.BCrypt.Verify(user.contrasenia, json.contrasenia);

            if (!verify)
            {
                return BadRequest("Usuario y/o contraseña incorrectos");
            }

			var token = this.tokenService.BuildToken("sddjjffgfjdkkdjhdfkhgf%&/sfgfgfd$%&/dghgfh%&H&%48487452", user);

            return Ok(token);
        }

        [HttpGet("{id}")]
		public async Task<ActionResult> Find(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			try
			{
				var item = await db.Usuarios.FindAsync(id);
				if (item == null)
				{
					return NotFound();
				}
				return Ok(item);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPut]
		public ActionResult Put([FromBody]Usuarios json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Usuarios.Where(a => a.id == json.id).FirstOrDefault();
				if (dbjson == null)
				{
					return BadRequest($"Ubicaciones with id json.id not found");
				}

				db.Entry(dbjson).CurrentValues.SetValues(json);
				db.Update(dbjson);
				db.SaveChanges();
				return Ok();
        }

		[HttpDelete]
		[Route("{id}")]
		public ActionResult Delete(int? id)
		{
			if (!ModelState.IsValid)
			return BadRequest("Invalid Information");
				var dbjson = db.Usuarios.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Usuarios with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
