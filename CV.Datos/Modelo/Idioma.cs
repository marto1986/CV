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
    
    public partial class Idioma
    {
        public int IdiomaId { get; set; }
        public int DatosPersonalesId { get; set; }
        public string NIvel { get; set; }
        public string Descripcion { get; set; }
    
        public virtual DatosPersonales DatosPersonales { get; set; }
    }
}
