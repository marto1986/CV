using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class ExperienciaLaboralDTO
    {
        [Key]
        public int ExperienciaLaboralId { get; set; }

        [Required()]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 10 caracteres")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [DataType(DataType.Date)]
        public System.DateTime FechaDesde { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [DataType(DataType.Date)]
        public System.DateTime FechaHasta { get; set; }

        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string ReferenciaNombre { get; set; }

        [DataType(DataType.PhoneNumber)]
        public Nullable<int> ReferenciaTelefono { get; set; }
    }
}
