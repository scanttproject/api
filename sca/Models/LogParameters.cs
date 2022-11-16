using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("LogParameters")]
	public class LogParameters
	{
		[Required]
		[Column("Id")]
		public int Id { get; set; }

		[Required]
		[Column("uriredirect")]
		public string uriredirect { get; set; }

		[Required]
		[Column("signoutredirecturi")]
		public string signoutredirecturi { get; set; }

		[Required]
		[Column("initiateloginuri")]
		public string initiateloginuri { get; set; }


	}
}
