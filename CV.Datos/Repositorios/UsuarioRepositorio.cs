using CV.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Datos.Repositorios
{
    public class UsuarioRepositorio
    {
        private CVEntities BD;

        public UsuarioRepositorio()
        {
            BD = new CVEntities();
        }

        /// <summary>
        /// Trae el listado de usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return BD.Usuario;
        }

        /// <summary>
        /// Trae un usuario por medio de su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario ObtenerUsuario(int id)
        {
            var dato = BD.Usuario.FirstOrDefault(x => x.UsuarioId == id);
            return dato;
        }

        /// <summary>
        /// Verifica si el usuario ya eciste
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool UsuarioExiste(string usuario)
        {
            var resultado = BD.Usuario.FirstOrDefault(x => x.UsuarioNombre == usuario);
            return Convert.ToBoolean(resultado);
        }

        /// <summary>
        /// Registra un nuevo usuario 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool Registrarse(Usuario usuario)
        {
            BD.Usuario.Add(usuario);
            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Actualiza los datos de un usuario
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool ActualizarUsuario(Usuario datos)
        {
            var actualizar = BD.Usuario.FirstOrDefault(x => x.UsuarioId == datos.UsuarioId);
            actualizar.UsuarioNombre = datos.UsuarioNombre;
            actualizar.UsuarioPassword = datos.UsuarioPassword;

            return BD.SaveChanges() > 0;
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Eliminar(int id)
        {
            var dato = BD.Usuario.FirstOrDefault(x => x.UsuarioId == id);
            BD.Usuario.Remove(dato);

            return BD.SaveChanges() > 0;
        }
    }
}
