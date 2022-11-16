using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Kaccountsexpo")]
	public class Kaccountsexpo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("delivery")]
		public string delivery { get; set; }

		[Column("customs")]
		public string customs { get; set; }

		[Column("aduanas")]
		public string aduanas { get; set; }

		[Column("estatus")]
		public string estatus { get; set; }

		[Column("tipodetransporte")]
		public string tipodetransporte { get; set; }


	}
}
