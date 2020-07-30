using CV.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class ExperienciaLaboralRepositorio
    {
        private CVEntities BD;

        public ExperienciaLaboralRepositorio()
        {
            BD = new CVEntities();
        }

        /// <summary>
        /// Trae toda la información de la experiencia laboral de todos los usuarios registrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExperienciaLaboral> ObtenerDatos()
        {
            return BD.ExperienciaLaboral;
        }

        /// <summary>
        /// Trae toda la información de la experiencia laboral de un usuario registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExperienciaLaboral ObtenerDato(int id)
        {
            var dato = BD.ExperienciaLaboral.FirstOrDefault(x => x.ExperienciaLaboralId == id);
            return dato;
        }

        /// <summary>
        /// Agrega nueva información de la experiencia laboral de un usuario registrado
        /// </summary>
        /// <param name="experienciaLaboral"></param>
        /// <returns></returns>
        public bool Agregar(ExperienciaLaboral experienciaLaboral)
        {
            BD.ExperienciaLaboral.Add(experienciaLaboral);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Edita la información de la experiencia laboral de un usuario registrado
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Actualizar(ExperienciaLaboral datos)
        {
            var actualizar = BD.ExperienciaLaboral.FirstOrDefault(x => x.ExperienciaLaboralId == datos.ExperienciaLaboralId);
            actualizar.Puesto = datos.Puesto;
            actualizar.UsuarioId = datos.UsuarioId;
            actualizar.Descripcion = datos.Descripcion;
            actualizar.FechaDesde = datos.FechaDesde;
            actualizar.FechaHasta = datos.FechaHasta;
            actualizar.ReferenciaNombre = datos.ReferenciaNombre;
            actualizar.ReferenciaTelefono = datos.ReferenciaTelefono;
            actualizar.Actualidad = datos.Actualidad;

            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina la información de la experiencia laboral de un usuario registrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var dato = BD.ExperienciaLaboral.FirstOrDefault(x => x.ExperienciaLaboralId == id);
            BD.ExperienciaLaboral.Remove(dato);

            return BD.SaveChanges() > 0;
        }
    }
}
