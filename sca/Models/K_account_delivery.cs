using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("k_account_delivery")]
	public class K_account_delivery
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("nombre")]
		public string nombre { get; set; }


	}
}
