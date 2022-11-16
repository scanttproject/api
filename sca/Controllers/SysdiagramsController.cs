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
	public class SysdiagramsController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Sysdiagrams>> Get()
		{
				 return Ok(db.Sysdiagrams.ToList());
		}

		private SCADB db;
		public SysdiagramsController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Sysdiagrams json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Sysdiagrams.Add(json);
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
				var item = await db.Sysdiagrams.FindAsync(id);
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
		public ActionResult Put([FromBody]Sysdiagrams json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Sysdiagrams.Where(a => a.diagram_id == json.diagram_id).FirstOrDefault();
				 if (dbjson == null);
				return BadRequest($"Sysdiagrams with id json.diagram_id not found");
				 dbjson.diagram_id = json.diagram_id;
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
				var dbjson = db.Sysdiagrams.Where(a => a.diagram_id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Sysdiagrams with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
