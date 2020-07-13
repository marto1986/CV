using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class EducacionDTO
    {
        [Key]
        [Required()]
        public int EducacionId { get; set; }

        [Required()]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string EstablecimientoEducativo { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [DataType(DataType.Date)]
        public System.DateTime FechaDesde { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [DataType(DataType.Date)]
        public System.DateTime FechaHasta { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string Estado { get; set; }
    }
}
