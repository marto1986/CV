//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CV.Datos.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class DatosPersonales
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
        public int UsuarioId { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
