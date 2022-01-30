﻿using PruebaIngresoBibliotecario.Api.Data;
using PruebaIngresoBibliotecario.Api.Domain;
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
            RespuestaDTO fechaDevolucion = new RespuestaDTO();
            fechaDevolucion.FechaMaximaDevolucion = CalcularFechaEntrega(prestamo.TipoUsuario);

            await _prestamoRepositorio.GuardarPrestamo(prestamo);

            return  fechaDevolucion;
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

    }
}
