using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDAL.DAL.DBContext;
using EntityDAL.DAL.Repositories.Contratos;
using EntityModel.Model;
using Microsoft.EntityFrameworkCore;


namespace EntityDAL.DAL.Repositories
{
    public class ProductoRepository:IProductoRepository
    {
        private readonly DBDPersona _context;

        public ProductoRepository(DBDPersona context)
        {
            _context = context;
        }
        
        //async: palabra clave que se usa para marcar un método como "asíncrono"

        //await esperar la finalización de una tarea (generalmente una operación asíncrona) sin bloquear
        //el hilo principal de ejecución.
        public async Task<RegistroPersona> GetPersonByIdAsync(int id)
        {
            return await _context.Registro.FindAsync(id);
        }

        public async Task<IEnumerable<RegistroPersona>> GetAllPersonsAsync()
        {
            return await _context.Registro.ToListAsync();
        }

        public async Task AddPersonAsync(RegistroPersona persona)
        {
        

            try
            {
                await _context.Registro.AddAsync(persona);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (puedes registrar `ex.Message` en un archivo o consola para depuración)
                Console.WriteLine("Error en SaveChangesAsync: " + ex.Message);
                throw; // Opcional: vuelve a lanzar la excepción si quieres que otros niveles también la manejen
            }

        }

        public async Task UpdatePersonAsync(RegistroPersona persona)
        {
            _context.Registro.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int id)
        {
            var producto = await _context.Registro.FindAsync(id);
            if (producto != null)
            {
                _context.Registro.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

    }
}
