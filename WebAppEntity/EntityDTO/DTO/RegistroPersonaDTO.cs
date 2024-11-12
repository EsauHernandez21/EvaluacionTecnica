using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDTO.DTO
{
    public class RegistroPersonaDTO
    {
        public int Id { get; set; }
        public string NombreCompania { get; set; }
        public string Contacto { get; set; }
        public string CorreoElectronico { get; set; }
        public int Telefono { get; set; }
    }
}
