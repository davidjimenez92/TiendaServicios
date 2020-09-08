using System;

namespace TiendaServicios.Api.CarritoCompra.RemoteModel
{
	public class LibroRemote
	{
		public Guid? LibreriaMaterialId { get; set; }
		public string Titulo { get; set; }
		public DateTime? FechaPublicacion { get; set; }
		public Guid? AutorLibro { get; set; }
	}
}
