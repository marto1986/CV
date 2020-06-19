using CV.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class DatosPersonalesRepositorio
    {
       private CVEntities BD;

        public DatosPersonalesRepositorio()
        {
            BD = new CVEntities();
        }

        /// <summary>
        /// Trae todos los datos de los usurios registrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DatosPersonales> ObtenerDatos()
        {
            return BD.DatosPersonales;
        }

        /// <summary>
        /// Trae los datos personales de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DatosPersonales ObtenerDato(int id)
        {
            var dato = BD.DatosPersonales.FirstOrDefault(x => x.DatospersonalesId == id);
            return dato;
        }

        /// <summary>
        /// Agrega nuevos datos personales
        /// </summary>
        /// <param name="datoPersonal"></param>
        /// <returns></returns>
        public bool Agregar(DatosPersonales datoPersonal)
        {
            BD.DatosPersonales.Add(datoPersonal);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Editar los datos personales
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Actualizar(DatosPersonales datos)
        {
            var actualizar = BD.DatosPersonales.FirstOrDefault(x => x.DatospersonalesId == datos.DatospersonalesId);
            actualizar.Nombres = datos.Nombres;
            actualizar.Apellido = datos.Apellido;
            actualizar.FechaNacimiento = datos.FechaNacimiento;
            actualizar.Nacionalidad = datos.Nacionalidad;
            actualizar.LugarNacimiento = datos.LugarNacimiento;
            actualizar.Domicilio = datos.Domicilio;
            actualizar.NroDomicilio = datos.NroDomicilio;
            actualizar.CodigoPostal = datos.CodigoPostal;
            actualizar.Email = datos.Email;
            actualizar.Telefono = datos.Telefono;

            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina los datos personales
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var dato = BD.DatosPersonales.FirstOrDefault(x => x.DatospersonalesId == id);
            BD.DatosPersonales.Remove(dato);

            return BD.SaveChanges() > 0;
        }
    }
}
