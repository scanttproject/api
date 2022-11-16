using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Movimientos")]
	public class Movimientos
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[ForeignKey("FK_tipomovimientiid")]
		[Column("tipomovimientiid")]
		public int? tipomovimientiid { get; set; }

		[ForeignKey("FK_usuarioid")]
		[Column("usuarioid")]
		public int? usuarioid { get; set; }

		[ForeignKey("FK_articuloid")]
		[Column("articuloid")]
		public int? articuloid { get; set; }

		[Column("fechamovimiento")]
		public DateTime? fechamovimiento { get; set; }

		[Column("cantidad")]
		public int? cantidad { get; set; }


		[JsonIgnore]
		public TipoMovimientos FK_tipomovimientiid{ get; set; }

		[JsonIgnore]
		public Usuarios FK_usuarioid{ get; set; }

		[JsonIgnore]
		public Articulos FK_articuloid{ get; set; }

	}
}
