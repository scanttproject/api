using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using sca.Models;

namespace sca.Controllers
{
		[ApiController]
	[Route("api/[controller]")]
	public class PerfilController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Perfil>> Get()
		{
				 return Ok(db.Perfil.ToList());
		}

		private SCADB db;
		public PerfilController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Perfil json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Perfil.Add(json);
				db.SaveChanges();
			return Ok();
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
				var item = await db.Perfil.FindAsync(id);
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
		public ActionResult Put([FromBody]Perfil json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Perfil.Where(a => a.idPerfil == json.idPerfil).FirstOrDefault();
				 if (dbjson == null);
				return BadRequest($"Perfil with id json.idPerfil not found");
				 dbjson.idPerfil = json.idPerfil;
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
				var dbjson = db.Perfil.Where(a => a.idPerfil == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Perfil with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
