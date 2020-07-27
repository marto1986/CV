using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class UsuarioDTO
    {
        [Required]
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo 30 caracteres")]
        public string UsuarioNombre { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(15, MinimumLength = 6)]
        [RegularExpression(@"^(?:.*[a-z]){7,}$", ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string UsuarioPassword { get; set; }

        public IEnumerable<ImagenDTO> imagenes { get; set; }
    }
}
