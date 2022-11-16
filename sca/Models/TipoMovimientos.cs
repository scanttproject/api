using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("TipoMovimientos")]
	public class TipoMovimientos
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("descripcion")]
		public string descripcion { get; set; }


	}
}
