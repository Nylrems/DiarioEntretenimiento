using Microsoft.AspNetCore.Mvc;
using DiarioEntretenimiento.LogicaNegocio.Servicios;


namespace DiarioEntretenimiento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntretenimientoController : ControllerBase
    {
        private readonly ServicioEntretenimiento _servicio;

        public EntretenimientoController(IConfiguration configuration)
        {
            string cadenaConexion = configuration.GetConnectionString("DefaultConnection");
            _servicio = new ServicioEntretenimiento(cadenaConexion);
        }

        [HttpGet]
        public IActionResult ObtenerCatalogo()
        {
            try
            {
                var datos = _servicio.ObtenerCatalogo();
                return Ok(datos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
