using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class DatosPersonalesDTO
    {
        [Key]
        [Required()]
        public int DatospersonalesId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string Apellido { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "el {0} es obligatorio")]
        public System.DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        public string LugarNacimiento { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        public string Domicilio { get; set; }

        
        public Nullable<int> NroDomicilio { get; set; }

        [DataType(DataType.PostalCode)]
        public string CodigoPostal { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Correo Electrónico inválido")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public Nullable<int> Telefono { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public IEnumerable<ImagenDTO> imagenes { get; set; }
    }
}
