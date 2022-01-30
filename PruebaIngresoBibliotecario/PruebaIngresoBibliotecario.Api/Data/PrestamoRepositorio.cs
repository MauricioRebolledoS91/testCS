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
             _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
        }

        public bool VerificarSiExisteUsusarioPorId(Prestamo prestamo)
        {

            var queryLondonCustomers = from cust in _context.Prestamos
                                       where cust.IdentificacionUsuario == prestamo.IdentificacionUsuario
                                       select cust;
            if (queryLondonCustomers.ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


    }
}
