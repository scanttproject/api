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
	public class MenuController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Menu>> Get()
		{
				 return Ok(db.Menu.ToList());
		}

		private SCADB db;
		public MenuController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Menu json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Menu.Add(json);
				db.SaveChanges();
			return Ok();
		}

		[HttpGet("{idMenu}")]
		public async Task<ActionResult> Find(int? idMenu)
		{
			if (idMenu == null)
			{
				return BadRequest();
			}
			try
			{
				var item = await db.Menu.FindAsync(idMenu);
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
		public ActionResult Put([FromBody]Menu json)
		{
				if (!ModelState.IsValid)
				return BadRequest("Invalid Information");
				var dbjson = db.Menu.Where(a => a.idMenu == json.idMenu).FirstOrDefault();
				 if (dbjson == null);
				return BadRequest($"Menu with id json.id not found");
				 dbjson.idMenu = json.idMenu;
				db.Update(dbjson);
				db.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		[Route("{idMenu}")]
		public ActionResult Delete(int? idMenu)
		{
			if (!ModelState.IsValid)
			return BadRequest("Invalid Information");
				var dbjson = db.Menu.Where(a => a.idMenu == idMenu).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Menu with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
