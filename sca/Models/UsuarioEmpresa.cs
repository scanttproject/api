using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("UsuarioEmpresa")]
	public class UsuarioEmpresa
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[ForeignKey("FK_usuarioid")]
		[Column("usuarioid")]
		public int? usuarioid { get; set; }

		[ForeignKey("FK_empresaid")]
		[Column("empresaid")]
		public int? empresaid { get; set; }


		[JsonIgnore]
		public Usuarios FK_usuarioid{ get; set; }

		[JsonIgnore]
		public Empresas FK_empresaid{ get; set; }

	}
}
