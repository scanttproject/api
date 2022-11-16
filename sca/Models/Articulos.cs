using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Articulos")]
	public class Articulos
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("descripcion")]
		public string descripcion { get; set; }

		[Column("rutaimagen")]
		public string rutaimagen { get; set; }

		[Column("cantidad")]
		public int? cantidad { get; set; }

		[ForeignKey("FK_ubicacionid")]
		[Column("ubicacionid")]
		public int? ubicacionId { get; set; }

		[Column("codigo")]
		public string codigo { get; set; }

		[Column("observaciones")]
		public string observaciones { get; set; }

		[ForeignKey("FK_estatusid")]
		[Column("estatusid")]
		public int? estatusid { get; set; }


		[JsonIgnore]
		public Ubicaciones FK_ubicacionid{ get; set; }

		[JsonIgnore]
		public Estatus FK_estatusid{ get; set; }

	}
}
