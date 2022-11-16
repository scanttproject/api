using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Despachos")]
	public class Despachos
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("supplier")]
		public string supplier { get; set; }

		[Column("aetc")]
		public string aetc { get; set; }

		[Column("forwarde")]
		public string forwarde { get; set; }

		[Column("hbl")]
		public string hbl { get; set; }

		[Column("pallets")]
		public int? pallets { get; set; }

		[Column("peso_kg")]
		public int? peso_kg { get; set; }

		[Column("comentarios")]
		public string comentarios { get; set; }


	}
}
