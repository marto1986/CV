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
    public class ConocimientoController : ApiController
    {
        private ConocimientoRepositorio repositorio;

        public ConocimientoController()
        {
            repositorio = new ConocimientoRepositorio();
        }

        [HttpGet]
        public IEnumerable<ConocimientoDTO> ObtenerDatos()
        {
            var listado = repositorio.ObtenerDatos();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public ConocimientoDTO ObtenerDato(int id)
        {
            var dato = repositorio.ObtenerDato(id);
            return dato.ToDTO();
        }

        [HttpPost]
        public bool Agregar(Conocimiento conocimiento)
        {
            var dato = repositorio.Agregar(conocimiento);
            return dato;
        }

        [HttpPut]
        public bool Actualizar(Conocimiento conocimiento)
        {
            var dato = repositorio.Actualizar(conocimiento);
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
