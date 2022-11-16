using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Perfiles")]
	public class Perfiles
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("descripcion")]
		public string descripcion { get; set; }

		[ForeignKey("FK_estatusid")]
		[Column("estatusid")]
		public int? estatusid { get; set; }


		[JsonIgnore]
		public Estatus FK_estatusid{ get; set; }

	}
}
