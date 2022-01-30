using PruebaIngresoBibliotecario.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Services
{
    public interface IPrestamoServicio
    {
        Task<RespuestaDTO> CrearPrestamo(Prestamo prestamo);
    }
}
