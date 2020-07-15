using System;
using CV.Datos.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class ObjetivoRepositorio
    {
        private CVEntities BD;

        public ObjetivoRepositorio()
        {
            BD = new CVEntities();
        }

        /// <summary>
        /// Trae toda la información sobre el objetivo de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Objetivo> ObtenerDatos()
        {
            return BD.Objetivo;
        }

        /// <summary>
        /// Trae la información sobre el objetivo de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Objetivo ObtenerDato(int id)
        {
            var dato = BD.Objetivo.FirstOrDefault(x => x.ObjetivoId == id);
            return dato;
        }

        /// <summary>
        /// Agrega nuevo objetivo
        /// </summary>
        /// <param name="objetivo"></param>
        /// <returns></returns>
        public bool Agregar(Objetivo objetivo)
        {
            BD.Objetivo.Add(objetivo);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Editar la información del objetivo
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Actualizar(Objetivo datos)
        {
            var actualizar = BD.Objetivo.FirstOrDefault(x => x.ObjetivoId == datos.ObjetivoId);
            actualizar.UsuarioId = datos.UsuarioId;
            actualizar.Descripcion = datos.Descripcion;

            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina la información del objetivo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var dato = BD.Objetivo.FirstOrDefault(x => x.ObjetivoId == id);
            BD.Objetivo.Remove(dato);

            return BD.SaveChanges() > 0;
        }
    }
}
