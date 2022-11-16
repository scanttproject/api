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
	public class VendorsController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Vendors>> Get()
		{
				 return Ok(db.Vendors.ToList());
		}

		private SCADB db;
		public VendorsController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Vendors json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Vendors.Add(json);
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
				var item = await db.Vendors.FindAsync(id);
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
		public ActionResult Put([FromBody]Vendors json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Vendors.Where(a => a.id == json.id).FirstOrDefault();
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
				var dbjson = db.Vendors.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Vendors with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
