using Microsoft.EntityFrameworkCore;

namespace sca.Models
{
	public class SCADB : DbContext
	{
		public SCADB(DbContextOptions<SCADB> options) : base(options) { }
		
public DbSet<Aduanas> Aduanas { get; set; }
public DbSet<Articulos> Articulos { get; set; }
public DbSet<Category> Category { get; set; }
public DbSet<Despachos> Despachos { get; set; }
public DbSet<Domesticos> Domesticos { get; set; }
public DbSet<Empresas> Empresas { get; set; }
public DbSet<Estatus> Estatus { get; set; }
public DbSet<Exportacion> Exportacion { get; set; }
public DbSet<Historial> Historial { get; set; }
public DbSet<Importacion> Importacion { get; set; }
public DbSet<K_account_customs> K_account_customs { get; set; }
public DbSet<K_account_delivery> K_account_delivery { get; set; }
public DbSet<K_account_main_f> K_account_main_f { get; set; }
public DbSet<K_account_status> K_account_status { get; set; }
public DbSet<Kaccountsexpo> Kaccountsexpo { get; set; }
public DbSet<Kaccountsimport> Kaccountsimport { get; set; }
public DbSet<LogParameters> LogParameters { get; set; }
public DbSet<Menu> Menu { get; set; }
public DbSet<Modulos> Modulos { get; set; }
public DbSet<Movimientos> Movimientos { get; set; }
public DbSet<Perfiles> Perfiles { get; set; }
public DbSet<PerfilModulo> PerfilModulo { get; set; }
public DbSet<Sysdiagrams> Sysdiagrams { get; set; }
public DbSet<Tipo_de_transporte> Tipo_de_transporte { get; set; }
public DbSet<TipoMovimientos> TipoMovimientos { get; set; }
public DbSet<Ubicaciones> Ubicaciones { get; set; }
public DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }
public DbSet<Usuarios> Usuarios { get; set; }
public DbSet<Vendors> Vendors { get; set; }
public DbSet<Rfpf> Rfpf { get; set; }
public DbSet<Salefoc> Salefoc { get; set; }
public DbSet<MenuPerfil> MenuPerfil { get; set; }
public DbSet<Perfil> Perfil { get; set; }

    }
}
