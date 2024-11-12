using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Model
{
    public class RegistroPersona
    {
        [Key]
        public int Id { get; set; }
        public string? NombreCompania { get; set; }
        public string? Contacto { get; set; } 
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; } 
    }

}
