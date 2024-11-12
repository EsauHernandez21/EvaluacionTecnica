using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebMvcApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebMvcApi.Services
{
    public class RegistroService
    {

        private readonly HttpClient _httpClient;

        public RegistroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obtener todos los productos
        public async Task<List<RegistroPersona>> ObtenerPersonsAsync()
        {
            var response = await _httpClient.GetAsync("/api/Registro/GetAllPersons");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RegistroPersona>>(content);
        }
      

        // Obtener un producto por ID
        public async Task<RegistroPersona> ObtenerProductoPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Productos/GetProductById/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegistroPersona>(content);
        }

       
        // Crear persona
        public async Task<bool> CrearPersonaAsync(RegistroPersona persona)
        {

      

            var json = JsonConvert.SerializeObject(persona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Registro/CreatePerson", content);
            return response.IsSuccessStatusCode;
        }

        // Actualizar un producto
        public async Task<bool> ActualizarProductoAsync(int id, RegistroPersona producto)
        {
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Productos/updateProduct/{id}", content);
            return response.IsSuccessStatusCode;
        }

        // Eliminar un producto SQL
        public async Task<bool> EliminarProductoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Productos/deleteProductById/{id}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<RegistroPersona>> ObtenerProductosOracleAsync()
        {
            var response = await _httpClient.GetAsync("/api/Productos/GetAllProductsOracle");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RegistroPersona>>(content);
        }

        
    }
}
