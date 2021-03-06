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
    public class UsuarioController : Controller
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrarse(UsuarioDTO usuario)
        {
            try
            {
                #region Verificar que el usuario no exista
                var Existe = UsuarioExiste(usuario.UsuarioNombre);

                if (Existe)
                {
                    ModelState.AddModelError("UsuarioNombre", "El Usuario ya existe.");
                    return View();
                }
                #endregion

                #region Encriptar la contraseña

                usuario.UsuarioPassword = Crypto.Hash(usuario.UsuarioPassword);

                #endregion

                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

                var request = clienteHttp.PostAsync("api/Usuario", usuario, new JsonMediaTypeFormatter()).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                    if (correcto)
                    {
                        var solicitud = clienteHttp.GetAsync("api/Usuario").Result;

                        if (solicitud.IsSuccessStatusCode)
                        {
                            var result = solicitud.Content.ReadAsStringAsync().Result;
                            var objUser = JsonConvert.DeserializeObject<List<UsuarioDTO>>(result);
                            var user = objUser.Where(x => x.UsuarioNombre == usuario.UsuarioNombre.Trim() && x.UsuarioPassword == usuario.UsuarioPassword.Trim());

                            if (user.Count() > 0)
                            {
                                Session["Usuario"] = user.First();
                                return RedirectToAction("Index", "DatosPersonales");
                            }
                        }

                    }

                    return View(usuario);
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
        public ActionResult IniciarSesion(string usuarioNombre, string usuarioPassword)
        {
            try
            {
                #region Encriptar la contraseña

                usuarioPassword = Crypto.Hash(usuarioPassword);

                #endregion

                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

                var request = clienteHttp.GetAsync("api/Usuario").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var objUser = JsonConvert.DeserializeObject<List<UsuarioDTO>>(resultString);
                    var user = objUser.Where(x => x.UsuarioNombre == usuarioNombre.Trim() && x.UsuarioPassword == usuarioPassword.Trim());

                    if (user.Count() > 0)
                    {
                        Session["Usuario"] = user.First();
                        return RedirectToAction("Index", "DatosPersonales");
                    }
                }
                var mensajeError = "Usuario y/o password incorrectos";
                ViewBag.Mensaje = mensajeError;
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }

        [HttpGet]
        private bool UsuarioExiste(string usuarioNom)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/Usuario").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<UsuarioDTO>>(resultString);
                var ok = listado.FirstOrDefault(x => x.UsuarioNombre == usuarioNom);

                if (ok != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }

            return false;
        }
    }
}