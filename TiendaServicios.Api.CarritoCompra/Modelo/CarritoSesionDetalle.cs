using System;

namespace TiendaServicios.Api.CarritoCompra.Modelo
{
	public class CarritoSesionDetalle
	{
		public int CarritoSesionDetalleId { get; set; }
		public DateTime? FechaCreacion { get; set; }
		public string ProductoSeleccionado { get; set; }
		public int CarritoSesionId { get; set; }
		public CarritoSesion CarritoSesion { get; set; }
	}
}
