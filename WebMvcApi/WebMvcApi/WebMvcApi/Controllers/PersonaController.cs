using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMvcApi.Models;
using WebMvcApi.Services;

namespace WebMvcApi.Controllers
{
    public class PersonaController : Controller
    {
        private readonly RegistroService _registroService;
        // Inyección de dependencias del servicio RegistroService
        
        public PersonaController(RegistroService registroService)
        {
            _registroService = registroService;
        }

        public IActionResult RegistroPersona()
        {
      
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistroPersona(RegistroPersona persona)
        {
            if (ModelState.IsValid)
            {
                

                var result = await _registroService.CrearPersonaAsync(persona); // Llamamos al servicio para hacer el insert
                if (result)
                {
                    // Si el insert es exitoso, pasamos los datos a la vista para mostrarlos en el modal
                    ViewBag.PersonaGuardada = persona;

                    // Mensaje de éxito
                    ViewBag.SuccessMessage = "Datos guardados correctamente.";

                    return View();
                }
                else
                {
                    // Si algo falla, puedes manejar el error de manera apropiada
                    ModelState.AddModelError("", "Ocurrió un error al crear la persona.");
                    return View();
                }
            }

            // Si el modelo no es válido, volvemos a mostrar el formulario con errores
            return View(persona);
        }

        // Acción para mostrar los registros
        public async Task<IActionResult> MostrarRegistros()
        {
            // Obtener los registros (con await)
            var registros = await _registroService.ObtenerPersonsAsync();

            // Pasar los registros a la vista
            return View(registros);
        }

    }
}


