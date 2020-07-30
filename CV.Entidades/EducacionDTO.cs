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
        [StringLength(100, ErrorMessage = "Solo 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(200, ErrorMessage = "Solo 200 caracteres")]
        public string EstablecimientoEducativo { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [DataType(DataType.Date)]
        public System.DateTime FechaDesde { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [DataType(DataType.Date)]
        public System.DateTime FechaHasta { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(10, ErrorMessage = "Solo 10 caracteres")]
        public string Estado { get; set; }

        [StringLength(200, ErrorMessage = "Solo 200 caracteres")]
        public string Comentario { get; set; }

        [StringLength(200, ErrorMessage = "Solo 200 caracteres")]
        public string Link { get; set; }
    }
}
