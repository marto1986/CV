using CV.Datos.Repositorios;
using CV.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CV.Datos.Extensiones;
using CV.Datos.Modelo;

namespace CV.API.Controllers
{
    public class ImagenController : ApiController
    {
        private ImagenRepositorio repositorio;

        public ImagenController()
        {
            repositorio = new ImagenRepositorio();
        }

        [HttpGet]
        public IEnumerable<ImagenDTO> ObtenerImagenes()
        {
            var listado = repositorio.TraerImagenes();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public ImagenDTO TraerImagen(int id)
        {
            var img = repositorio.TraerImagen(id);
            return img.ToDTO();
        }

        [HttpPost]
        public bool Agregar(Imagen imagen)
        {
            var dato = repositorio.Agregar(imagen);
            return dato;
        }

        [HttpPut]
        public bool Actualizar(Imagen img)
        {
            var dato = repositorio.Actualizar(img);
            return dato;
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            var dato = repositorio.Eliminar(id);
            return dato;
        }
    }
}
