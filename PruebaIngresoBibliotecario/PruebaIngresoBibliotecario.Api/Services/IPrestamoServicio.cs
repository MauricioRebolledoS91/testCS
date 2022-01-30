using PruebaIngresoBibliotecario.Api.Domain;
using PruebaIngresoBibliotecario.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Services
{
    public interface IPrestamoServicio
    {
        Task<RespuestaDTO> CrearPrestamo(Prestamo prestamo);
        //Task<RespuestaDTO> ObtenerUsuario(Prestamo prestamo);
    }
}
