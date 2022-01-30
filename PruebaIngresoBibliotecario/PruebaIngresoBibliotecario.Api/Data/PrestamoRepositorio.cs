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

        public async Task<Prestamo> GuardarPrestamo(Prestamo prestamo)
        {
             _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return await _context.Set<Prestamo>().FindAsync(prestamo.Id);
        }

        public bool VerificarSiExisteUsusarioPorId(Prestamo prestamo)
        {

            var usuarioConPrestamo = from prest in _context.Prestamos
                                       where prest.IdentificacionUsuario == prestamo.IdentificacionUsuario
                                       select prest;

            if (usuarioConPrestamo.ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<Prestamo> ObtenerPrestamoPorId(string id)
        {
            return await _context.Set<Prestamo>().FindAsync(id);
        }
    }
}
