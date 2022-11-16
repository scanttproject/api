using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Usuarios")]
	public class Usuarios
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("nombreusuario")]
		public string nombreusuario { get; set; }

		[Column("nombre")]
		public string nombre { get; set; }

		[Column("apellidopaterno")]
		public string apellidopaterno { get; set; }

		[Column("apellidomaterno")]
		public string apellidomaterno { get; set; }

		[Column("contrasenia")]
		public string contrasenia { get; set; }

		[ForeignKey("FK_perfilid")]
		[Column("perfilid")]
		public int? perfilid { get; set; }

		[ForeignKey("FK_estatusid")]
		[Column("estatusid")]
		public int? estatusid { get; set; }


		[JsonIgnore]
		public Perfiles FK_perfilid{ get; set; }

		[JsonIgnore]
		public Estatus FK_estatusid{ get; set; }

	}
}
