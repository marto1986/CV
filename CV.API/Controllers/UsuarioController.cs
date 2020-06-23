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
    public class UsuarioController : ApiController
    {
        private UsuarioRepositorio repositorio;

        public UsuarioController()
        {
            repositorio = new UsuarioRepositorio();
        }

        [HttpPost]
        public bool UsuarioExiste(string usuario)
        {
            var dato = repositorio.UsuarioExiste(usuario);
            return dato;
        }

        [HttpGet]
        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            var listado = repositorio.ObtenerUsuarios();
            return listado.Select(x => x.ToDTO());
        }

        [HttpGet]
        public UsuarioDTO ObtenerUsuario(int id)
        {
            var dato = repositorio.ObtenerUsuario(id);
            return dato.ToDTO();
        }

        [HttpPost]
        public bool Registrarse(Usuario usuario)
        {
            var dato = repositorio.Registrarse(usuario);
            return dato;
        }

        public bool Actualizar(Usuario usuario)
        {
            var dato = repositorio.ActualizarUsuario(usuario);
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
