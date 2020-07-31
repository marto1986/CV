using CV.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using log4net;

namespace CV.Web.Controllers
{
    public class ObjetivoController : Controller
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult Index()
        {
            try
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

                var request = clienteHttp.GetAsync("api/Objetivo").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var listado = JsonConvert.DeserializeObject<List<ObjetivoDTO>>(resultString);
                    var resultado = listado.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);

                    return View(resultado);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            try
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
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(ObjetivoDTO objetivo)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PostAsync("api/Objetivo", objetivo, new JsonMediaTypeFormatter()).Result;

            try
            {
                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                    if (correcto)
                    {
                        return RedirectToAction("index");
                    }
                    return View(objetivo);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View(objetivo);
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            try
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

                var request = clienteHttp.GetAsync("api/Objetivo/" + id).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var informacion = JsonConvert.DeserializeObject<ObjetivoDTO>(resultString);

                    return View(informacion);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar(ObjetivoDTO objetivo)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PutAsync("api/Objetivo/", objetivo, new JsonMediaTypeFormatter()).Result;

            try
            {
                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                    if (correcto)
                    {
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.DeleteAsync("api/Objetivo/" + id).Result;

            try
            {
                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                    if (correcto)
                    {
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/Objetivo/" + id).Result;

            try
            {
                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var informacion = JsonConvert.DeserializeObject<ObjetivoDTO>(resultString);

                    return View(informacion);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }
    }
}