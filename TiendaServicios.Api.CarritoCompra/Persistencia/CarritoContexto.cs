using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Modelo;

namespace TiendaServicios.Api.CarritoCompra.Persistencia
{
	public class CarritoContexto: DbContext
	{
		public CarritoContexto(DbContextOptions<CarritoContexto> options): base(options){	}
		public DbSet<CarritoSesion> CarritoSerion { get; set; }
		public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }
	}
}
