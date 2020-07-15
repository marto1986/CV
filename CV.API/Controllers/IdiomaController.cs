using CV.Datos.Repositorios;
using CV.Entidades;
using CV.Datos.Extensiones;
using CV.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CV.API.Controllers
{
    public class IdiomaController : ApiController
    {
        private IdiomaRepositorio repositorio;

        public IdiomaController()
        {
            repositorio = new IdiomaRepositorio();
        }

        [HttpGet]
        public IEnumerable<IdiomaDTO> ObtenerDatos()
        {
            var listado = repositorio.ObtenerDatos();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public IdiomaDTO ObtenerDato(int id)
        {
            var dato = repositorio.ObtenerDato(id);
            return dato.ToDTO();
        }

        [HttpPost]
        public bool Agregar(Idioma idioma)
        {
            var dato = repositorio.Agregar(idioma);
            return dato;
        }

        [HttpPut]
        public bool Actualizar(Idioma idioma)
        {
            var dato = repositorio.Actualizar(idioma);
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
