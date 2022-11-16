using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Exportacion")]
	public class Exportacion
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("destinatario")]
		public string destinatario { get; set; }

		[Column("vendor")]
		public string vendor { get; set; }

		[Column("aetcnumber")]
		public string aetcnumber { get; set; }

		[Column("rf_pf")]
		public string rf_pf { get; set; }

		[Column("incoterm")]
		public string incoterm { get; set; }

		[Column("planner")]
		public string planner { get; set; }

		[Column("tipo_de_material")]
		public string tipo_de_material { get; set; }

		[Column("customer")]
		public string customer { get; set; }

		[Column("program")]
		public string program { get; set; }

		[Column("sale_foc")]
		public string sale_foc { get; set; }

		[Column("aduana")]
		public string aduana { get; set; }

		[Column("picked_update")]
		public DateTime? picked_update { get; set; }

		[Column("day")]
		public string day { get; set; }

		[Column("deliverydate")]
		public DateTime? deliverydate { get; set; }

		[Column("wk")]
		public int? wk { get; set; }

		[Column("sr")]
		public string sr { get; set; }

		[Column("glfinance")]
		public string glfinance { get; set; }

		[Column("proforma")]
		public string proforma { get; set; }

		[Column("cfdi")]
		public string cfdi { get; set; }

		[Column("estatus")]
		public string estatus { get; set; }

		[Column("comentarios")]
		public string comentarios { get; set; }

		[Column("carrier")]
		public string carrier { get; set; }

		[Column("caja")]
		public int? caja { get; set; }

		[Column("guiadestino")]
		public int? guiadestino { get; set; }

		[Column("tipo_de_transporte")]
		public string tipo_de_transporte { get; set; }

		[Column("aa")]
		public string aa { get; set; }

		[Column("aetc")]
		public string aetc { get; set; }

		[Column("carrierdosinland")]
		public string carrierdosinland { get; set; }

		[Column("tipo_transporte")]
		public string tipo_transporte { get; set; }

		[Column("guiaags_aa")]
		public string guiaags_aa { get; set; }

		[Column("pallets")]
		public int? pallets { get; set; }

		[Column("pesokg")]
		public double? pesokg { get; set; }

		[Column("cargobase")]
		public string cargobase { get; set; }

		[Column("esign")]
		public string esign { get; set; }

		[Column("customerdos")]
		public string customerdos { get; set; }

		[Column("programdos")]
		public string programdos { get; set; }


	}
}
