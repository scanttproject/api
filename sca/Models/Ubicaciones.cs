using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Ubicaciones")]
	public class Ubicaciones
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("anaquel")]
		public string anaquel { get; set; }

		[Column("ventana")]
		public string ventana { get; set; }

		[Column("fila")]
		public string fila { get; set; }

		[Column("columna")]
		public string columna { get; set; }

		[Column("codigo")]
		public string codigo { get; set; }

		[ForeignKey("FK_estatusid")]
		[Column("estatusid")]
		public int? estatusid { get; set; }


		[JsonIgnore]
		public Estatus FK_estatusid{ get; set; }

	}
}
