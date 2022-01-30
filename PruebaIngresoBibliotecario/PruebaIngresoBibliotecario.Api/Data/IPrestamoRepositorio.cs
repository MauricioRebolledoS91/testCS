using PruebaIngresoBibliotecario.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Data
{
    public interface IPrestamoRepositorio
    {
        Task<Prestamo> GuardarPrestamo(Prestamo prestamo);

        bool VerificarSiExisteUsusarioPorId(Prestamo prestamo);

        Task<Prestamo> ObtenerPrestamoPorId(string id);
    }
}
