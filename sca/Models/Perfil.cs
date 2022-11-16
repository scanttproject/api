using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Perfil")]
	public class Perfil
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("idPerfil")]
		public int idPerfil { get; set; }

		[Column("nombre")]
		public string nombre { get; set; }

		[ForeignKey("FK_EstatusId")]
		[Column("estatusId")]
		public int? estatusId { get; set; }


		[JsonIgnore]
		public Estatus FK_EstatusId{ get; set; }

	}
}
