using PruebaIngresoBibliotecario.Api.Data;
using PruebaIngresoBibliotecario.Api.Domain;
using PruebaIngresoBibliotecario.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Services
{
    public class PrestamoServicio : IPrestamoServicio
    {
        IPrestamoRepositorio _prestamoRepositorio;
        public PrestamoServicio(IPrestamoRepositorio prestamoRepositorio)
        {
            _prestamoRepositorio = prestamoRepositorio;
        }

        public async Task<RespuestaDTO> CrearPrestamo(Prestamo prestamo)
        {
            RespuestaDTO respuesta = new RespuestaDTO();
            var existeUsuarioConPrestamo = _prestamoRepositorio.VerificarSiExisteUsusarioPorId(prestamo);
            if(!existeUsuarioConPrestamo)
            {
                prestamo.Id = Guid.NewGuid().ToString();
                prestamo.FechaMaximaDevolucion = CalcularFechaEntrega(prestamo.TipoUsuario);

                var prestamoCreado = await _prestamoRepositorio.GuardarPrestamo(prestamo);
                respuesta.Id = prestamoCreado.Id;
                respuesta.FechaMaximaDevolucion = prestamo.FechaMaximaDevolucion;
            }
            else
            {
                respuesta.Mensaje = $"El usuario con identificacion {prestamo.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo";
            }

            return respuesta;

        }

        public DateTime CalcularFechaEntrega(TipoUsuarioPrestamo tipoUsuario)
        {
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fechaDevolucion = DateTime.Now;
            int diasPrestamo = tipoUsuario switch
            {
                TipoUsuarioPrestamo.AFILIADO => 10,
                TipoUsuarioPrestamo.EMPLEADO => 8,
                TipoUsuarioPrestamo.INVITADO => 7,
                _ => -1,
            };

            for (int i = 0; i < diasPrestamo;)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                i = (!weekend.Contains(fechaDevolucion.DayOfWeek)) ? ++i : i;
            }

            return fechaDevolucion;
        }

        public async Task<RespuestaDTO> ObtenerPrestamoPorId(string prestamoId)
        {
            var respuestaDto = new RespuestaDTO();
            try
            {
                var prestamo = await _prestamoRepositorio.ObtenerPrestamoPorId(prestamoId);

                respuestaDto.Id = prestamo.Id;
                respuestaDto.IdentificacionUsuario = prestamo.IdentificacionUsuario;
                respuestaDto.Isbn = prestamo.Isbn;
                respuestaDto.FechaMaximaDevolucion = prestamo.FechaMaximaDevolucion;
            
            }
            catch(Exception)
            {
                respuestaDto.Mensaje = $"El prestamo con id {prestamoId} no existe";
            }
            return respuestaDto;
        }
    }
}
