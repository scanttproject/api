using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Vendors")]
	public class Vendors
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("supplier_raw_material")]
		public string supplier_raw_material { get; set; }

		[Column("vendor")]
		public int? vendor { get; set; }

		[Column("incomer")]
		public string incomer { get; set; }

		[Column("planner")]
		public string planner { get; set; }


	}
}
