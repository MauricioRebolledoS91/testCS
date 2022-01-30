using PruebaIngresoBibliotecario.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Dto
{
    public class RespuestaDTO
    {
        public string Id { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; }
        public string Mensaje { get; set; }
    }
}
