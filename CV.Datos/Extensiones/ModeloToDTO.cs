using CV.Datos.Modelo;
using CV.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Extensiones
{
    public static class ModeloToDTO
    {
        public static DatosPersonalesDTO ToDTO(this DatosPersonales model)
        {
            return new DatosPersonalesDTO
            {
                DatospersonalesId = model.DatospersonalesId,
                Nombres = model.Nombres,
                Apellido = model.Apellido,
                FechaNacimiento = model.FechaNacimiento,
                Nacionalidad = model.Nacionalidad,
                LugarNacimiento = model.LugarNacimiento,
                Domicilio = model.Domicilio,
                NroDomicilio = model.NroDomicilio,
                CodigoPostal = model.CodigoPostal,
                Email = model.Email,
                Telefono = model.Telefono,
                imagenes = model.Imagen.Select(x => x.ToDTO())
            };
        }

        public static ImagenDTO ToDTO(this Imagen model)
        {
            return new ImagenDTO
            {
                ImagenId = model.ImagenId,
                Nombre = model.Nombre,
                DatosPersonalesId = model.DatosPersonalesId
            };
        }
    }
}
