using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class ConocimientoDTO
    {
        public int ConocimientoId { get; set; }
        public int DatosPersonalesId { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; }
    }
}
