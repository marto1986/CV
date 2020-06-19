using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class RegistroDTO
    {
        public int RegistroId { get; set; }
        public int DatosPersonalesId { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public Nullable<bool> ConfirmacionEmail { get; set; }
    }
}
