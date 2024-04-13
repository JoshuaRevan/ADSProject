using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]

        public string NombresEstudiantes { get; set; }
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres.")]

        public string ApellidosEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un Campo requerido")]
        [MinLength(length: 12, ErrorMessage = "La longitud del campo no puede ser a 12 caracteres.")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser a 12 caracteres.")]

        public string CodigoEstudiante { get; set; }
        [Required(ErrorMessage = "Este es un Campo requerido")]
        [MinLength(length: 254, ErrorMessage = "La longitud del campo no puede ser a 254 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato de correo electronico .")]

        public string CorreoEstudiante { get;set; }


    }
}
