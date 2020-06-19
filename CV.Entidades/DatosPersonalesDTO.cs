using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class DatosPersonalesDTO
    {
        public int DatospersonalesId { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string LugarNacimiento { get; set; }
        public string Domicilio { get; set; }
        public Nullable<int> NroDomicilio { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public Nullable<int> Telefono { get; set; }

        public IEnumerable<ImagenDTO> imagenes { get; set; }
    }
}
