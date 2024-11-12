using EntityModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDAL.DAL.Repositories.Contratos;


namespace EntityBLL.BLL
{
    public class ProductoService:IProductoService
    {
      
        private readonly IProductoRepository _productoRepository;
       
        


        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // Implementación para obtener todos los registros
        public async Task<IEnumerable<RegistroPersona>> ObtenerTodosLosPersonasAsync()
        {
            return await _productoRepository.GetAllPersonsAsync();
        }

       

        public async Task<RegistroPersona> ObtenerPerssonaPorIdAsync(int id)
        {
            return await _productoRepository.GetPersonByIdAsync(id);
        }


        public async Task AgregarPersonaAsync(RegistroPersona persona)
        {
         
            await _productoRepository.AddPersonAsync(persona);
        }


        public async Task ActualizarPersonaAsync(RegistroPersona persona)
        {
         
            await _productoRepository.UpdatePersonAsync(persona);
        }



        public async Task EliminarPersonaAsync(int id)
        {
            await _productoRepository.DeletePersonAsync(id);
        }
    }
}
