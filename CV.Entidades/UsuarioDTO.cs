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
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 6)]
        public string UsuarioPassword { get; set; }

        public IEnumerable<ImagenDTO> imagenes { get; set; }
    }
}
