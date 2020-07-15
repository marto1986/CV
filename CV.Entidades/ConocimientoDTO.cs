using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class ConocimientoDTO
    {
        [Key]
        public int ConocimientoId { get; set; }

        [Required()]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(20, ErrorMessage = "Solo 20 caracteres")]
        public string Nivel { get; set; }
    }
}
