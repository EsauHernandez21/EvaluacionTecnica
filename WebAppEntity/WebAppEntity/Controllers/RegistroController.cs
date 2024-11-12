using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityBLL.BLL;
using EntityModel.Model;


namespace WebAppEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {

        //La BLL llama a la capa DAL para acceder a los datos necesarios
        private readonly IProductoService _productoService;
  

   
        // Constructor que acepta los dos servicios
        public RegistroController(IProductoService productoService)
        {
            _productoService = productoService;
           
        }

        [HttpGet("GetAllPersons")]
        public async Task<IEnumerable<RegistroPersona>> GetPersonas()
        {

        
            return await _productoService.ObtenerTodosLosPersonasAsync();
        }

        [HttpGet("GetPersonById/{id}")]
        public async Task<ActionResult<RegistroPersona>> GetProducto(int id)
        {
         


            var producto = await _productoService.ObtenerPerssonaPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost("CreatePerson")]
        public async Task<ActionResult> PostPerson(RegistroPersona persona)
        {
         
            await _productoService.AgregarPersonaAsync(persona);
            return NoContent();
        }

        [HttpPut("updatePerson/{id}")]
        public async Task<ActionResult> PutProducto(int id, RegistroPersona persona)
        {
            
        
            await _productoService.ActualizarPersonaAsync(persona);
            return NoContent();
        }

        [HttpDelete("deletePersontById/{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            await _productoService.EliminarPersonaAsync(id);
            return NoContent();
        }

      
    }
}
