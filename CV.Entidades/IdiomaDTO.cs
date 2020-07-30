using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class IdiomaDTO
    {
        [Key]
        public int IdiomaId { get; set; }

        [Required()]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo 30 caracteres")]
        public string NivelEscrito { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "Solo 30 caracteres")]
        public string NivelOral { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(200, ErrorMessage = "Solo 200 caracteres")]
        public string Descripcion { get; set; }
    }
}
