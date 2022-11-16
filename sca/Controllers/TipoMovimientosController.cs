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
	public class TipoMovimientosController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<TipoMovimientos>> Get()
		{
				 return Ok(db.TipoMovimientos.ToList());
		}

		private SCADB db;
		public TipoMovimientosController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]TipoMovimientos json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.TipoMovimientos.Add(json);
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
				var item = await db.TipoMovimientos.FindAsync(id);
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
		public ActionResult Put([FromBody]TipoMovimientos json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.TipoMovimientos.Where(a => a.id == json.id).FirstOrDefault();
				 if (dbjson == null);
				return BadRequest($"TipoMovimientos with id json.Id not found");
				 dbjson.id = json.id;
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
				var dbjson = db.TipoMovimientos.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"TipoMovimientos with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
