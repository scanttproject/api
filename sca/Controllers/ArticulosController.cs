using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using sca.Models;
using Microsoft.EntityFrameworkCore;

namespace sca.Controllers
{
		[ApiController]
	[Route("api/[controller]")]
	public class ArticulosController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<Articulos>> Get()
		{
				 return Ok(db.Articulos.ToList());
		}

		private SCADB db;
		public ArticulosController(SCADB database)		{
			this.db = database;
		}

		[HttpPost]
		public ActionResult Post([FromBody]Articulos json)
		{
			if (!ModelState.IsValid)
				return BadRequest("Iinvalid information");

				db.Articulos.Add(json);
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
				var item = await db.Articulos.FindAsync(id);
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
        [HttpGet]
        [Route("[action]/{codigo}")]
        public async Task<ActionResult> articuloConUbicacion(string codigo)
        {
            if (codigo == null)
            {
                return BadRequest();
            }
            try
            {
				var list = await (from articulo in db.Articulos
				join ubicacion in db.Ubicaciones
				on articulo.ubicacionId equals ubicacion.id
				where articulo.codigo == codigo
				select new
				{
                    descripcion = articulo.descripcion,
					anaquel = ubicacion.anaquel,
					columna = ubicacion.columna,
					cantidad = articulo.cantidad,
					fila = ubicacion.fila,
					ventana = ubicacion.ventana
				}).FirstOrDefaultAsync();

            return Ok(list);
        }
            catch (Exception e)
            {
                return StatusCode(500, e);
    }
}

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> articuloConUbicacion()
        {
            try
            {
                var list = await (from articulo in db.Articulos
                                  join ubicacion in db.Ubicaciones
                                  on articulo.ubicacionId equals ubicacion.id
                                  select new
                                  {
                                      id = articulo.id,
                                      descripcion = articulo.descripcion,
                                      anaquel = ubicacion.anaquel,
                                      columna = ubicacion.columna,
                                      cantidad = articulo.cantidad,
                                      fila = ubicacion.fila,
                                      ventana = ubicacion.ventana
                                  }).ToListAsync();

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut]
		public ActionResult Put([FromBody]Articulos json)
		{
			if (!ModelState.IsValid)
			return BadRequest("Invalid Information");
			var dbjson = db.Articulos.Where(a => a.id == json.id).FirstOrDefault();
				if (dbjson == null){
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
				var dbjson = db.Articulos.Where(a => a.id == id).FirstOrDefault();
			if (dbjson == null)
				return BadRequest($"Articulos with id int not found");
				db.Remove(dbjson);
				db.SaveChanges();
					return Ok();
		}

	}
}
