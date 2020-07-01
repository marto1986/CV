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
    public class DatosPersonalesController : Controller
    {
        // GET: DatosPersonales
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

            var request = clienteHttp.GetAsync("api/DatosPersonales").Result;

            if(request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<DatosPersonalesDTO>>(resultString);

                return View(listado);
            }

            return View(new List<DatosPersonalesDTO>());
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
        public ActionResult Nuevo(DatosPersonalesDTO datosPersonales)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PostAsync("api/DatosPersonales", datosPersonales, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if(correcto)
                {
                    return RedirectToAction("index");
                }
                return View(datosPersonales);
            }

            return View(datosPersonales);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/DatosPersonales" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<DatosPersonalesDTO>(resultString);

                return View(informacion);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(DatosPersonalesDTO datosPersonales)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PutAsync("api/DatosPersonales", datosPersonales, new JsonMediaTypeFormatter()).Result;

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

            var request = clienteHttp.DeleteAsync("api/DatosPersonales" + id).Result;

            if(request.IsSuccessStatusCode)
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

            var request = clienteHttp.GetAsync("api/DatosPersonales" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<DatosPersonalesDTO>(resultString);

                return View(informacion);
            }

            return View();
        }
    }
}