using PruebaIngresoBibliotecario.Api.Domain;
using PruebaIngresoBibliotecario.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Data
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        public PersistenceContext _context { get; set; }
        public PrestamoRepositorio(PersistenceContext context)
        {
            _context = context;
        }

        public async Task GuardarPrestamo(Prestamo prestamo)
        {
            await _context.AddAsync(prestamo);
        }


    }
}
