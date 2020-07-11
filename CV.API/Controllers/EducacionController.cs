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
    public class EducacionController : ApiController
    {
        private EducacionRepositorio repositorio;

        public EducacionController()
        {
            repositorio = new EducacionRepositorio();
        }

        [HttpGet]
        public IEnumerable<EducacionDTO> ObtenerDatos()
        {
            var listado = repositorio.ObtenerDatos();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public EducacionDTO ObtenerDato(int id)
        {
            var dato = repositorio.ObtenerDato(id);
            return dato.ToDTO();
        }

        [HttpPost]
        public bool Agregar(Educacion educacion)
        {
            var dato = repositorio.Agregar(educacion);
            return dato;
        }

        [HttpPut]
        public bool Actualizar(Educacion educacion)
        {
            var dato = repositorio.Actualizar(educacion);
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
