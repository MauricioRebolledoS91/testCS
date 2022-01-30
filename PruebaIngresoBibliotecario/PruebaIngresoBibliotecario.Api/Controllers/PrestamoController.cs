using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Api.Domain;
using PruebaIngresoBibliotecario.Api.Dto;
using PruebaIngresoBibliotecario.Api.Services;
using System.Threading.Tasks;

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
        public async Task<ActionResult<RespuestaDTO>> Create([FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _prestamoServicio.CrearPrestamo(prestamo));
        }

        [HttpGet("{idPrestamo}", Name = "ObtenerPrestamoPorId")]
        public async Task<ActionResult<RespuestaDTO>> Get(string idPrestamo)
        {
            var respuesta = new RespuestaDTO();
            respuesta = await _prestamoServicio.ObtenerPrestamoPorId(idPrestamo);
            if (respuesta == null)
            {
                return NotFound();
            }
            return Ok(respuesta);
        }
    }
}
