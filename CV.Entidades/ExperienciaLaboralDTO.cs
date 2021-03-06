﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Entidades
{
    public class ExperienciaLaboralDTO
    {
        [Key]
        public int ExperienciaLaboralId { get; set; }

        [Required()]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "Solo 100 caracteres")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [StringLength(200, ErrorMessage = "Solo 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "el {0} es obligatorio")]
        [DataType(DataType.Date)]
        public System.DateTime FechaDesde { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaHasta { get; set; }

        [StringLength(50, ErrorMessage = "Solo 50 caracteres")]
        public string ReferenciaNombre { get; set; }

        [DataType(DataType.PhoneNumber)]
        public Nullable<int> ReferenciaTelefono { get; set; }

        public Nullable<bool> Actualidad { get; set; }
    }
}
