using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("sysdiagrams")]
	public class Sysdiagrams
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("diagram_id")]
		public int diagram_id { get; set; }

		[Column("version")]
		public int? version { get; set; }

		[Column("definition")]
		public byte[] definition { get; set; }


	}
}
