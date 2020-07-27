using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CV.Entidades
{
    public class ImagenDTO
    {
        [Key]
        public int ImagenId { get; set; }

        [Required()]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        
        public string Nombre { get; set; }

        public IEnumerable<ImagenDTO> imagenes { get; set; }

    }
}
