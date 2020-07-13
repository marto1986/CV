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
        public static UsuarioDTO ToDTO(this Usuario model)
        {
            return new UsuarioDTO
            {
                UsuarioId = model.UsuarioId,
                UsuarioNombre = model.UsuarioNombre,
                UsuarioPassword = model.UsuarioPassword,
                imagenes = model.Imagen.Select(x => x.ToDTO())
            };
        }

        public static DatosPersonalesDTO ToDTO(this DatosPersonales model)
        {
            return new DatosPersonalesDTO
            {
                DatospersonalesId = model.DatospersonalesId,
                UsuarioId = model.UsuarioId,
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
                
            };
        }

        public static ImagenDTO ToDTO(this Imagen model)
        {
            return new ImagenDTO
            {
                ImagenId = model.ImagenId,
                Nombre = model.Nombre,
                UsuarioId = model.UsuarioId
            };
        }

        

        public static EducacionDTO ToDTO(this Educacion model)
        {
            return new EducacionDTO
            {
                EducacionId = model.EducacionId,
                UsuarioId = model.UsuarioId,
                Titulo = model.Titulo,
                EstablecimientoEducativo = model.EstablecimientoEducativo,
                FechaDesde = model.FechaDesde,
                FechaHasta = model.FechaHasta,
                Estado = model.Estado
            };
        }

        public static ExperienciaLaboralDTO ToDTO(this ExperienciaLaboral model)
        {
            return new ExperienciaLaboralDTO
            {
                ExperienciaLaboralId = model.ExperienciaLaboralId,
                UsuarioId = model.UsuarioId,
                Puesto = model.Puesto,
                Descripcion = model.Descripcion,
                FechaDesde = model.FechaDesde,
                FechaHasta = model.FechaHasta,
                ReferenciaNombre = model.ReferenciaNombre,
                ReferenciaTelefono = model.ReferenciaTelefono
            };
        }
    }
}
