using CV.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using CV.Web.Models.ViewModels;

namespace CV.Web.Controllers
{
    public class ImagenController : Controller
    {
        ImageViewModel img = new ImageViewModel();

        // GET: Imagen
        [HttpGet]
        public ActionResult Index()
        {
            #region Obtengo el ID del usuario
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
            }
            else
            {
                var objUsuario = Session["Usuario"];
                ViewBag.ObjUsuario = objUsuario;
            }
            #endregion

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/Imagen").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<ImagenDTO>>(resultString);
                if (ViewBag.ObjUsuario != null)
                {
                    var resultado = listado.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
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
            #region Obtengo el ID del usuario
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
            }
            else
            {
                var objUsuario = Session["Usuario"];
                ViewBag.ObjUsuario = objUsuario;
            }
            #endregion

            #region ViewModel para subir la imagen al servidor
            var model = new ImageViewModel
            {
                foto = img.foto
            };

            ViewBag.Img = model;
            #endregion

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ImagenDTO imagen, ImageViewModel img)
        {
            
            string ImageName = System.IO.Path.GetFileName(img.foto.FileName);
            imagen.Nombre = ImageName;

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PostAsync("api/Imagen", imagen, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                
                string physicalPath = Server.MapPath("~/Content/Imagenes/Upload/" + ImageName);

                img.foto.SaveAs(physicalPath);

                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("index");
                }

                return View(imagen);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            #region Obtengo el ID del usuario
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
            }
            else
            {
                var objUsuario = Session["Usuario"];
                ViewBag.ObjUsuario = objUsuario;
            }
            #endregion


            #region ViewModel para subir la imagen al servidor
            var model = new ImageViewModel
            {
                foto = img.foto
            };

            ViewBag.Img = model;
            #endregion

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/Imagen/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<ImagenDTO>(resultString);

                return View(informacion);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(ImagenDTO imagen, ImageViewModel img)
        {
            string ImageName = System.IO.Path.GetFileName(img.foto.FileName);
            imagen.Nombre = ImageName;

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PutAsync("api/Imagen/", imagen, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                if(Convert.ToBoolean(System.IO.File.Exists(img.foto.FileName)) == true)
                {
                    #region Elimina la imagen del servidor
                    var peticion = clienteHttp.GetAsync("api/Imagen").Result;

                    if (peticion.IsSuccessStatusCode)
                    {
                        var resultadoString = request.Content.ReadAsStringAsync().Result;
                        var listado = JsonConvert.DeserializeObject<List<ImagenDTO>>(resultadoString);

                        if (ViewBag.ObjUsuario != null)
                        {
                            var resultado = listado.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                            System.IO.File.Delete(resultado.Nombre);
                        }
                    }
                    #endregion
                }

                #region Carga la nueva imagen
                string physicalPath = Server.MapPath("~/Content/Imagenes/Upload/" + ImageName);
                img.foto.SaveAs(physicalPath);
                #endregion

                var resultString = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(resultString);

                if (correcto)
                {
                    return RedirectToAction("index");
                }

                return View(imagen);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.DeleteAsync("api/Imagen/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                if (System.IO.File.Exists(img.foto.FileName) == true)
                {
                    #region Elimina la imagen del servidor
                    var peticion = clienteHttp.GetAsync("api/Imagen").Result;

                    if (peticion.IsSuccessStatusCode)
                    {
                        var resultadoString = request.Content.ReadAsStringAsync().Result;
                        var listado = JsonConvert.DeserializeObject<List<ImagenDTO>>(resultadoString);

                        if (ViewBag.ObjUsuario != null)
                        {
                            var resultado = listado.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                            System.IO.File.Delete(resultado.Nombre);
                        }
                    }
                    #endregion
                }


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
            #region Obtengo el ID del usuario
            if (Session["Usuario"] == null)
            {
                Session["Usuario"] = null;
            }
            else
            {
                var objUsuario = Session["Usuario"];
                ViewBag.ObjUsuario = objUsuario;
            }
            #endregion

            #region ViewModel para subir la imagen al servidor
            var model = new ImageViewModel
            {
                foto = img.foto
            };

            ViewBag.Img = model;
            #endregion

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.GetAsync("api/Imagen/" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<ImagenDTO>(resultString);

                return View(informacion);
            }

            return View();
        }
    }
}