using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("MenuPerfil")]
	public class MenuPerfil
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[ForeignKey("FK_IdPerfil")]
		[Column("idPerfil")]
		public int? idPerfil { get; set; }

		[ForeignKey("FK_IdMenu")]
		[Column("idMenu")]
		public int? idMenu { get; set; }


		[JsonIgnore]
		public Perfil FK_IdPerfil{ get; set; }

		[JsonIgnore]
		public Menu FK_IdMenu{ get; set; }

	}
}
