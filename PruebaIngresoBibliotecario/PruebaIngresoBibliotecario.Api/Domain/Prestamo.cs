using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Domain
{
    public class Prestamo
    {
        [Key]
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; }
        public TipoUsuarioPrestamo TipoUsuario { get; set; }
    }

    public enum TipoUsuarioPrestamo { AFILIADO = 1, EMPLEADO, INVITADO }
}
