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
    public class ExperienciaLaboralController : ApiController
    {
        private ExperienciaLaboralRepositorio repositorio;

        public ExperienciaLaboralController()
        {
            repositorio = new ExperienciaLaboralRepositorio();
        }

        [HttpGet]
        public IEnumerable<ExperienciaLaboralDTO> ObtenerDatos()
        {
            var listado = repositorio.ObtenerDatos();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public ExperienciaLaboralDTO ObtenerDato(int id)
        {
            var dato = repositorio.ObtenerDato(id);
            return dato.ToDTO();
        }

        [HttpPost]
        public bool Agregar(ExperienciaLaboral experiencia)
        {
            var dato = repositorio.Agregar(experiencia);
            return dato;
        }

        [HttpPut]
        public bool Actualizar(ExperienciaLaboral experiencia)
        {
            var dato = repositorio.Actualizar(experiencia);
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
