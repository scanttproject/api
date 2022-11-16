using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("rfpf")]
	public class Rfpf
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Required]
		[Column("nombre")]
		public string nombre { get; set; }


	}
}
