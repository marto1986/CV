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
    public class ExperienciaLaboralController : Controller
    {
        // GET: ExperienciaLaboral
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
            }
            else
            {
                var objUsuario = Session["Usuario"];
                ViewBag.ObjUsuario = objUsuario;
            }

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/ExperienciaLaboral").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<ExperienciaLaboralDTO>>(resultString);
                if (ViewBag.ObjUsuario != null)
                {
                    var resultado = listado.Where(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                    return View(resultado);
                }
                else
                {
                    return View(listado);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
            }
            else
            {
                var objUsuario = Session["Usuario"];
                ViewBag.ObjUsuario = objUsuario;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ExperienciaLaboralDTO experiencia)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PostAsync("api/ExperienciaLaboral", experiencia, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("index");
                }
                return View(experiencia);
            }

            return View(experiencia);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
            }
            else
            {
                var objUsuario = Session["Usuario"];
                ViewBag.ObjUsuario = objUsuario;
            }

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/ExperienciaLaboral/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<ExperienciaLaboralDTO>(resultString);

                return View(informacion);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(ExperienciaLaboralDTO experiencia)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PutAsync("api/ExperienciaLaboral/", experiencia, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("index");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.DeleteAsync("api/ExperienciaLaboral/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("index");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/ExperienciaLaboral/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<ExperienciaLaboralDTO>(resultString);

                return View(informacion);
            }

            return View();
        }
    }
}