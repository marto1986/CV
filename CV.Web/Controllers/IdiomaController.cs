﻿using CV.Entidades;
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
    public class IdiomaController : Controller
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

                var request = clienteHttp.GetAsync("api/Idioma").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var listado = JsonConvert.DeserializeObject<List<IdiomaDTO>>(resultString);
                    if (ViewBag.ObjUsuario != null)
                    {
                        var resultado = listado.Where(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId).OrderByDescending(x => x.IdiomaId);
                        return View(resultado);
                    }
                    else
                    {
                        return View(listado);
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
        public ActionResult Nuevo(IdiomaDTO idioma)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PostAsync("api/Idioma", idioma, new JsonMediaTypeFormatter()).Result;

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
                    return View(idioma);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View(idioma);
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

                var request = clienteHttp.GetAsync("api/Idioma/" + id).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var informacion = JsonConvert.DeserializeObject<IdiomaDTO>(resultString);

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
        public ActionResult Actualizar(IdiomaDTO idioma)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PutAsync("api/Idioma/", idioma, new JsonMediaTypeFormatter()).Result;

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

            var request = clienteHttp.DeleteAsync("api/Idioma/" + id).Result;

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

            var request = clienteHttp.GetAsync("api/Idioma/" + id).Result;

            try
            {
                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var informacion = JsonConvert.DeserializeObject<IdiomaDTO>(resultString);

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