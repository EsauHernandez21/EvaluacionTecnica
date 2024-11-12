using EntityModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityDAL.DAL.Repositories.Contratos
{
    public interface IProductoRepository
    {
        //Es una operación asíncrona
        Task<RegistroPersona> GetPersonByIdAsync(int id);
        //Es una interfaz en C# que representa una colección de elementos se puede recorrer o iterar sobre ellos,
        //generalmente mediante un bucle foreach
        Task<IEnumerable<RegistroPersona>> GetAllPersonsAsync();
        Task AddPersonAsync(RegistroPersona persona);
        Task UpdatePersonAsync(RegistroPersona persona);
        //Task indica que el método es asíncrono  y se ejecuta en segundo plano
        Task DeletePersonAsync(int id);
    }
}
