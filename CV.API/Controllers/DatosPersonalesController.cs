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
    public class DatosPersonalesController : ApiController
    {
        private DatosPersonalesRepositorio repositorio;

        public DatosPersonalesController()
        {
            repositorio = new DatosPersonalesRepositorio();
        }

        [HttpGet]
        public IEnumerable<DatosPersonalesDTO> ObtenerDatos()
        {
            var listado = repositorio.ObtenerDatos();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public DatosPersonalesDTO ObtenerDato(int id)
        {
            var dato = repositorio.ObtenerDato(id);
            return dato.ToDTO();
        }

        [HttpPost]
        public bool Agregar(DatosPersonales datosPersonal)
        {
            var dato = repositorio.Agregar(datosPersonal);
            return dato;
        }

        [HttpPut]
        public bool Actualizar(DatosPersonales datosPersonal)
        {
            var dato = repositorio.Actualizar(datosPersonal);
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
