using Microsoft.AspNetCore.Mvc;
using DiarioEntretenimiento.LogicaNegocio.Servicios;
using DiarioEntretenimiento.AccesoDatos.Modelos;


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

        [HttpPost]
        public IActionResult CrearItem([FromBody] ItemEntretenimiento item)
        {
            // [FromBody] busca los datos en el cuerpo del json que envía el cliente

            try
            {
                int idGenerado = _servicio.AgregarNuevo(item);

                // Devolvemos un código 200 ok, y el ID nuevo.
                // Esto le confirma al frontend que todo salió bien.
                return Ok(new { mensaje = "Creado con éxito", id = idGenerado });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
