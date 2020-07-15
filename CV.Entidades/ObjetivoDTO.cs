using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class ObjetivoDTO
    {
        [Key]
        public int ObjetivoId { get; set; }

        [Required()]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string Descripcion { get; set; }
    }
}
