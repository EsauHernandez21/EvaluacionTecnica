using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.Model;

namespace EntityBLL.BLL
{
    public interface IProductoService
    {
        Task<IEnumerable<RegistroPersona>> ObtenerTodosLosPersonasAsync();
        Task<RegistroPersona> ObtenerPerssonaPorIdAsync(int id);
        Task AgregarPersonaAsync(RegistroPersona persona);
        Task ActualizarPersonaAsync(RegistroPersona persona);
        Task EliminarPersonaAsync(int id);
    }
}
