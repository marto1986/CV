using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class IdiomaDTO
    {
        public int IdiomaId { get; set; }
        public int UsuarioId { get; set; }
        public string NIvel { get; set; }
        public string Descripcion { get; set; }
    }
}
