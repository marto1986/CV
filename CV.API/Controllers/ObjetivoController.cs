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
    public class ObjetivoController : ApiController
    {
        private ObjetivoRepositorio repositorio;

        public ObjetivoController()
        {
            repositorio = new ObjetivoRepositorio();
        }

        [HttpGet]
        public IEnumerable<ObjetivoDTO> ObtenerDatos()
        {
            var listado = repositorio.ObtenerDatos();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public ObjetivoDTO ObtenerDato(int id)
        {
            var dato = repositorio.ObtenerDato(id);
            return dato.ToDTO();
        }

        [HttpPost]
        public bool Agregar(Objetivo objetivo)
        {
            var dato = repositorio.Agregar(objetivo);
            return dato;
        }

        [HttpPut]
        public bool Actualizar(Objetivo objetivo)
        {
            var dato = repositorio.Actualizar(objetivo);
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
