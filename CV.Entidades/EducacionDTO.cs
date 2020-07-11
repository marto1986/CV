using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class EducacionDTO
    {
        public int EducacionId { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string EstablecimientoEducativo { get; set; }
        public System.DateTime FechaDesde { get; set; }
        public System.DateTime FechaHasta { get; set; }
        public string Estado { get; set; }
    }
}
