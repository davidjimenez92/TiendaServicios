using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
	public class Consulta
	{
		public class Ejecuta : IRequest<CarritoDto>
		{
			public int CarritoSesionId { get; set; }
		}

		public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
		{
			private readonly CarritoContexto _contexto;
			private readonly ILibrosService _libroService;

			public Manejador(CarritoContexto contexto, ILibrosService libroService)
			{
				_contexto = contexto;
				_libroService = libroService;
			}

			public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
			{
				var carritoSesion = await _contexto.CarritoSerion.FirstOrDefaultAsync(carrito => carrito.CarritoSesionId == request.CarritoSesionId);
				var carritoSesionDetalle = await _contexto.CarritoSesionDetalle.Where(carrito => carrito.CarritoSesionId == request.CarritoSesionId).ToListAsync();

				var listaCarritoDto = new List<CarritoDetalleDto>();

				foreach (var libro in carritoSesionDetalle)
				{
					var response = await _libroService.GetLibro(new Guid(libro.ProductoSeleccionado));
					if (response.resultado)
					{
						var objetoLibro = response.Libro;
						var carritoDetalle = new CarritoDetalleDto
						{
							TituloLibro = objetoLibro.Titulo,
							FechaPublicacion = objetoLibro.FechaPublicacion,
							LibroId = objetoLibro.LibreriaMaterialId
						};
						listaCarritoDto.Add(carritoDetalle);
					}						
				}
				var carritoSesionDto = new CarritoDto
				{
					CarritoId = carritoSesion.CarritoSesionId,
					FechaCreacionSesion = carritoSesion.FechaCreacion,
					ListaProductos = listaCarritoDto
				};

				return carritoSesionDto;
			}
		}
	}
}
