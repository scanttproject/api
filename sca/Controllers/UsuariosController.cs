using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using sca.Models;
using Microsoft.EntityFrameworkCore;
using sca.Services;
using sca.Interfaces;
using sca.Models.Request;

namespace sca.Controllers
{
		[ApiController]
	[Route("api/[controller]")]
	public class UsuariosController : Controller
	{
		private ITokenService tokenService;
		private SCADB db;
		private IUserService _userService;
        public UsuariosController(SCADB database, ITokenService tokenService, IUserService userService = null)
        {
            this.db = database;
            this.tokenService = tokenService;
            _userService = userService;
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
			    json.contrasenia = EncryptServices.GetSHA256(json.contrasenia);

                db.Usuarios.Add(json);
				db.SaveChanges();
			return Ok();
		}

        /// <summary>
        /// login nuevo
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <summary>
        /// login nuevo
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public ActionResult login(AuthRequest model)
        {
			var userresponser = _userService.Auth(model);
			if(userresponser == null)
            {
				return BadRequest("Usuario o Contrasena Incorrecta");

            }
			return Ok(userresponser);
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
