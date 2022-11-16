using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Historial")]
	public class Historial
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("descripcion")]
		public string descripcion { get; set; }

		[ForeignKey("FK_usuarioid")]
		[Column("usuarioid")]
		public int? usuarioid { get; set; }

		[Column("fecha")]
		public DateTime? fecha { get; set; }


		[JsonIgnore]
		public Usuarios FK_usuarioid{ get; set; }

	}
}
