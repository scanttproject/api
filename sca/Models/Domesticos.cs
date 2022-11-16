using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Domesticos")]
	public class Domesticos
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("origen")]
		public string origen { get; set; }

		[Column("destino")]
		public string destino { get; set; }

		[Column("vendor")]
		public string vendor { get; set; }

		[Column("aetc")]
		public string aetc { get; set; }

		[Column("wk")]
		public decimal? wk { get; set; }

		[Column("rfpf")]
		public string rfpf { get; set; }

		[Column("planner")]
		public string planner { get; set; }

		[Column("tipodematerial")]
		public string tipodematerial { get; set; }

		[Column("salefoc")]
		public string salefoc { get; set; }

		[Column("po")]
		public string po { get; set; }

		[Column("pickupdate")]
		public DateTime? pickupdate { get; set; }

		[Column("putime")]
		public string putime { get; set; }

		[Column("deliverydate")]
		public DateTime? deliverydate { get; set; }

		[Column("deliverytime")]
		public string deliverytime { get; set; }

		[Column("tipodeoperacion")]
		public string tipodeoperacion { get; set; }

		[Column("transport")]
		public string transport { get; set; }

		[Column("trackingno")]
		public string trackingno { get; set; }

		[Column("tipodetransporte")]
		public string tipodetransporte { get; set; }

		[Column("incoterm")]
		public string incoterm { get; set; }

		[Column("estatus")]
		public string estatus { get; set; }

		[Column("comentarios")]
		public string comentarios { get; set; }

		[Column("totalskids")]
		public int? totalskids { get; set; }

		[Column("grossweight")]
		public int? grossweight { get; set; }

		[Column("cargobase")]
		public string cargobase { get; set; }

		[Column("esign")]
		public int? esign { get; set; }

		[Column("customer")]
		public string customer { get; set; }

		[Column("program")]
		public string program { get; set; }


	}
}
