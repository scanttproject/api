using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using sca.Models;
using Microsoft.AspNetCore.Authorization;

namespace sca.Controllers
{
		[ApiController]
	[Route("api/[controller]")]
	public class AduanasController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Aduanas>> Get()
		{
				 return Ok(db.Aduanas.ToList());
		}

		private SCADB db;
		public AduanasController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Aduanas json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Aduanas.Add(json);
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
				var item = await db.Aduanas.FindAsync(id);
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
		public ActionResult Put([FromBody]Aduanas json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Aduanas.Where(a => a.id == json.id).FirstOrDefault();
				 if (dbjson == null);
				return BadRequest($"Aduanas with id json.id not found");
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
				var dbjson = db.Aduanas.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Aduanas with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
