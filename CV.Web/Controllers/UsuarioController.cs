using CV.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;

namespace CV.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(UsuarioDTO usuario)
        {
            bool Status = false;
            string Message = "";

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PostAsync("api/Usuario", usuario, new JsonMediaTypeFormatter()).Result;

            #region
                var Existe = UsuarioExiste(usuario.UsuarioNombre);

                if (Existe)
                {
                    ModelState.AddModelError("EmailExiste", "El Email ya existe.");
                    return View(request);
                }
            #endregion

            #region Encriptar la contraseña

                usuario.UsuarioPassword = Crypto.Hash(usuario.UsuarioPassword);
            
            #endregion

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    Message = "Registro correcto";
                    Status = true;
                    return RedirectToAction("index", "DatosPersonales");
                }
                else
                {
                    Status = false;
                }
                return View(usuario);
            }

            return View();
        }

        private bool UsuarioExiste(string email)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PostAsync("api/Usuario", email, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}