using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("PerfilModulo")]
	public class PerfilModulo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[ForeignKey("FK_perfilesid")]
		[Column("perfilesid")]
		public int? perfilesid { get; set; }

		[ForeignKey("FK_modulosid")]
		[Column("modulosid")]
		public int? modulosid { get; set; }


		[JsonIgnore]
		public Perfiles FK_perfilesid{ get; set; }

		[JsonIgnore]
		public Modulos FK_modulosid{ get; set; }

	}
}
