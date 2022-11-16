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
	public class LogParametersController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<LogParameters>> Get()
		{
				 return Ok(db.LogParameters.ToList());
		}

		private SCADB db;
		public LogParametersController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]LogParameters json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.LogParameters.Add(json);
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
				var item = await db.LogParameters.FindAsync(id);
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
		public ActionResult Put([FromBody]LogParameters json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.LogParameters.Where(a => a.Id == json.Id).FirstOrDefault();
				 if (dbjson == null);
				return BadRequest($"LogParameters with id json.id not found");
				 dbjson.Id = json.Id;
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
				var dbjson = db.LogParameters.Where(a => a.Id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"LogParameters with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
