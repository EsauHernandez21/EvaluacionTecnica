using System.ComponentModel.DataAnnotations;

namespace WebMvcApi.Models
{
    public class RegistroPersona
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la compañía es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre de la compañía solo debe contener letras y espacios")]
        public string nombrecompania { get; set; } // Representa "nombreCompania"
        
        [Required(ErrorMessage = "El nombre de la persona de contacto es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre de la persona de contacto solo debe contener letras y espacios")]
        public string contacto { get; set; } // Representa "contacto"


        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|net|org|gov|edu|co|io)$", ErrorMessage = "El correo electrónico debe tener un formato válido")]
        public string correoElectronico { get; set; } // Representa "correoElectronico"


        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe contener exactamente 10 dígitos numéricos.")]
        public string telefono { get; set; } // Representa "telefono"

    }
}
