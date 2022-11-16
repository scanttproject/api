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
	public class DespachosController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Despachos>> Get()
		{
				 return Ok(db.Despachos.ToList());
		}

		private SCADB db;
		public DespachosController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Despachos json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Despachos.Add(json);
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
				var item = await db.Despachos.FindAsync(id);
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
		public ActionResult Put([FromBody]Despachos json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Despachos.Where(a => a.id == json.id).FirstOrDefault();
				if (dbjson == null)
				{
					return BadRequest($"Articulos with id json.id not found");
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
				var dbjson = db.Despachos.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Despachos with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
