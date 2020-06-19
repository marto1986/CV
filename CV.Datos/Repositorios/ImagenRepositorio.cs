using CV.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class ImagenRepositorio
    {
        private CVEntities BD;

        public ImagenRepositorio()
        {
            BD = new CVEntities();
        }

        public IEnumerable<Imagen> TraerImagenes()
        {
            return BD.Imagen;
        }

        /// <summary>
        /// Trae una imagen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Imagen TraerImagen(int id)
        {
            var dato = BD.Imagen.FirstOrDefault(x => x.ImagenId == id);
            return dato;
        }

        /// <summary>
        /// Agrega la imagen
        /// </summary>
        /// <param name="imagen"></param>
        /// <returns></returns>
        public bool Agregar(Imagen imagen)
        {
            BD.Imagen.Add(imagen);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Actualiza la imagen
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public bool Actualizar(Imagen img)
        {
            var actualizar = BD.Imagen.FirstOrDefault(x => x.ImagenId == img.ImagenId);
            actualizar.Nombre = img.Nombre;
            
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina la imagen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var img = BD.Imagen.FirstOrDefault(x => x.ImagenId == id);
            BD.Imagen.Remove(img);

            return BD.SaveChanges() > 0;
        }
    }
}
