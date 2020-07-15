using System;
using CV.Datos.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class IdiomaRepositorio
    {
        private CVEntities BD;

        public IdiomaRepositorio()
        {
            BD = new CVEntities();
        }

        /// <summary>
        /// Trae toda la información sobre la formación educativa de idiomas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Idioma> ObtenerDatos()
        {
            return BD.Idioma;
        }

        /// <summary>
        /// Trae toda la información sobre la formación de idiomas de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Idioma ObtenerDato(int id)
        {
            var dato = BD.Idioma.FirstOrDefault(x => x.IdiomaId == id);
            return dato;
        }

        /// <summary>
        /// Agrega nueva información de idiomas
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public bool Agregar(Idioma idioma)
        {
            BD.Idioma.Add(idioma);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Editar la información de su formación educativa
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Actualizar(Idioma datos)
        {
            var actualizar = BD.Idioma.FirstOrDefault(x => x.IdiomaId == datos.IdiomaId);
            actualizar.UsuarioId = datos.UsuarioId;
            actualizar.NivelEscrito = datos.NivelEscrito;
            actualizar.NivelOral = datos.NivelOral;
            actualizar.Descripcion = datos.Descripcion;

            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina la información de idioma
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var dato = BD.Idioma.FirstOrDefault(x => x.IdiomaId == id);
            BD.Idioma.Remove(dato);

            return BD.SaveChanges() > 0;
        }
    }
}
