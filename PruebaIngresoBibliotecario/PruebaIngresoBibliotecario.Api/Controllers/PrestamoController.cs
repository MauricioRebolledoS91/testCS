using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Api.Domain;
using PruebaIngresoBibliotecario.Api.Services;
using System.Threading.Tasks;
using System.Text.Json;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        IPrestamoServicio _prestamoServicio;
        public PrestamoController(IPrestamoServicio prestamoServicio)
        {
            _prestamoServicio = prestamoServicio;
        }

        [HttpPost(Name = "AgregarPrestamo")]
        public async Task<ActionResult<RespuestaDTO>> Create([FromBody] Prestamo createEventCommand)
        {
            var respuesta = new RespuestaDTO();
            respuesta = await _prestamoServicio.CrearPrestamo(createEventCommand);
            return Ok(respuesta);
        }
    }
}
