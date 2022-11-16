using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace sca.Models
{
	[Table("Importacion")]
	public class Importacion
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int id { get; set; }

		[Column("supplier")]
		public string supplier { get; set; }

		[Column("vendor")]
		public int? vendor { get; set; }

		[Column("wk")]
		public int? wk { get; set; }

		[Column("referencia_interna")]
		public string referencia_interna { get; set; }

		[Column("rf_pf")]
		public string rf_pf { get; set; }

		[Column("planner")]
		public string planner { get; set; }

		[Column("category")]
		public string category { get; set; }

		[Column("po")]
		public int? po { get; set; }

		[Column("pick_up_date")]
		public DateTime? pick_up_date { get; set; }

		[Column("estimated_time_of_departure")]
		public DateTime? estimated_time_of_departure { get; set; }

		[Column("intercom")]
		public string intercom { get; set; }

		[Column("aduana")]
		public string aduana { get; set; }

		[Column("eta_port")]
		public DateTime? eta_port { get; set; }

		[Column("weta")]
		public int? weta { get; set; }

		[Column("customs_clearance")]
		public DateTime? customs_clearance { get; set; }

		[Column("cw_customs")]
		public int? cw_customs { get; set; }

		[Column("eta_ct_ags")]
		public DateTime? eta_ct_ags { get; set; }

		[Column("transit_time")]
		public int? transit_time { get; set; }

		[Column("cw_continental")]
		public int? cw_continental { get; set; }

		[Column("week_day")]
		public string week_day { get; set; }

		[Column("forwarder")]
		public string forwarder { get; set; }

		[Column("numero_de_guia")]
		public string numero_de_guia { get; set; }

		[Column("tipo_de_transporte")]
		public string tipo_de_transporte { get; set; }

		[Column("estatus")]
		public string estatus { get; set; }

		[Column("comentarios")]
		public string comentarios { get; set; }

		[Column("pallets")]
		public int? pallets { get; set; }

		[Column("peso_kg")]
		public int? peso_kg { get; set; }

        [Column("referenciainterna")]
        public string referenciainterna { get; set; }

        [Column("transporteterrestre")]
        public string transporteterrestre { get; set; }

        [Column("tipotransporte")]
        public string tipotransporte { get; set; }


    }
}
