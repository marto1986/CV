using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class ExperienciaLaboralDTO
    {
        public int ExperienciaLaboralId { get; set; }
        public int UsuarioId { get; set; }
        public string Puesto { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaDesde { get; set; }
        public System.DateTime FechaHasta { get; set; }
        public string ReferenciaNombre { get; set; }
        public Nullable<int> ReferenciaTelefono { get; set; }
    }
}
