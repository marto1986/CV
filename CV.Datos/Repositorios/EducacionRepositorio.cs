using System;
using CV.Datos.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class EducacionRepositorio
    {
        private CVEntities BD;

        public EducacionRepositorio()
        {
            BD = new CVEntities();
        }

        /// <summary>
        /// Trae toda la información sobre la formación educativa de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Educacion> ObtenerDatos()
        {
            return BD.Educacion;
        }

        /// <summary>
        /// Trae toda la información sobre la formación educativa de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Educacion ObtenerDato(int id)
        {
            var dato = BD.Educacion.FirstOrDefault(x => x.EducacionId == id);
            return dato;
        }

        /// <summary>
        /// Agrega nueva información educactiva
        /// </summary>
        /// <param name="educacion"></param>
        /// <returns></returns>
        public bool Agregar(Educacion educacion)
        {
            BD.Educacion.Add(educacion);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Editar la información de su formación educativa
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Actualizar(Educacion datos)
        {
            var actualizar = BD.Educacion.FirstOrDefault(x => x.EducacionId == datos.EducacionId);
            actualizar.UsuarioId = datos.UsuarioId;
            actualizar.Titulo = datos.Titulo;
            actualizar.EstablecimientoEducativo = datos.EstablecimientoEducativo;
            actualizar.FechaDesde = datos.FechaDesde;
            actualizar.FechaHasta = datos.FechaHasta;
            actualizar.Estado = datos.Estado;
            actualizar.Comentario = datos.Comentario;
            actualizar.link = datos.link;

            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina la información educativa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var dato = BD.Educacion.FirstOrDefault(x => x.EducacionId == id);
            BD.Educacion.Remove(dato);

            return BD.SaveChanges() > 0;
        }
    }
}
