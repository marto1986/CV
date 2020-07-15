using System;
using CV.Datos.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class ConocimientoRepositorio
    {
        private CVEntities BD;

        public ConocimientoRepositorio()
        {
            BD = new CVEntities();
        }

        /// <summary>
        /// Trae toda la información sobre los conocimientos de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Conocimiento> ObtenerDatos()
        {
            return BD.Conocimiento;
        }

        /// <summary>
        /// Trae toda la información sobre los conocimientos de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Conocimiento ObtenerDato(int id)
        {
            var dato = BD.Conocimiento.FirstOrDefault(x => x.ConocimientoId == id);
            return dato;
        }

        /// <summary>
        /// Agrega nuevo conocimiento
        /// </summary>
        /// <param name="conocimiento"></param>
        /// <returns></returns>
        public bool Agregar(Conocimiento conocimiento)
        {
            BD.Conocimiento.Add(conocimiento);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Editar la información del conocimiento
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Actualizar(Conocimiento datos)
        {
            var actualizar = BD.Conocimiento.FirstOrDefault(x => x.ConocimientoId == datos.ConocimientoId);
            actualizar.UsuarioId = datos.UsuarioId;
            actualizar.Descripcion = datos.Descripcion;
            actualizar.Nivel = datos.Nivel;

            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina la información del conocimiento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var dato = BD.Conocimiento.FirstOrDefault(x => x.ConocimientoId == id);
            BD.Conocimiento.Remove(dato);

            return BD.SaveChanges() > 0;
        }
    }
}
