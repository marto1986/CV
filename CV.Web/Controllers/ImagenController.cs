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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace CV.Web.Controllers
{
    public class ImagenController : Controller
    {
        ImageViewModel img = new ImageViewModel();

        
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
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(ImagenDTO imagen, ImageViewModel img)
        {
            var random = new Random().Next(0, 100);
            string extension = Path.GetExtension(img.foto.FileName);
            bool extensionOk = ValidarExtension(extension);

            if (extensionOk == true)
            {
                Redimensionar(img.foto.InputStream);
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
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar(ImagenDTO imagen, ImageViewModel img)
        {
            var random = new Random().Next(0, 100);
            string extension = Path.GetExtension(img.foto.FileName);
            bool extensionOk = ValidarExtension(extension);

            if (extensionOk == true)
            {
                Image imagenRedimensionada = Redimensionar(img.foto.InputStream);
                string ImageName = System.IO.Path.GetFileName(img.foto.FileName);
                ImageName = random + ImageName;
                imagen.Nombre = ImageName;

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:5476/");

            var request = clienteHttp.PutAsync("api/Imagen/", imagen, new JsonMediaTypeFormatter()).Result;

                if (request.IsSuccessStatusCode)
                {
                    
                        #region Elimina la imagen del servidor
                        var peticion = clienteHttp.DeleteAsync("api/Imagen/" + imagen.ImagenId).Result;

                        if (peticion.IsSuccessStatusCode)
                        {
                            var resultadoStringEliminar = request.Content.ReadAsStringAsync().Result;
                            var listado = JsonConvert.DeserializeObject<List<ImagenDTO>>(resultadoStringEliminar);

                            if (ViewBag.ObjUsuario != null)
                            {
                                var resultado = listado.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                                System.IO.File.Delete(resultado.Nombre);
                            }
                        }
                        #endregion
                    

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

                #region Elimina la imagen del servidor

                if (request.IsSuccessStatusCode)
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

        /// <summary>
        /// Método para verificar la extensión del archivo
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        private bool ValidarExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Método privado para redimencionar la imagen a 200px
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <returns></returns>
        private static Image Redimensionar(Stream stream)
        {
            // Se crea un objeto Image, que contiene las propiedades de la imagen
            Image img = Image.FromStream(stream);

            // Tamaño máximo de la imagen (altura o anchura)
            const int max = 200;

            int h = img.Height;
            int w = img.Width;
            int newH, newW;

            if (h > w && h > max)
            {
                // Si la imagen es vertical y la altura es mayor que max,
                // se redefinen las dimensiones.
                newH = max;
                newW = (w * max) / h;
            }
            else if (w > h && w > max)
            {
                // Si la imagen es horizontal y la anchura es mayor que max,
                // se redefinen las dimensiones.
                newW = max;
                newH = (h * max) / w;
            }
            else
            {
                newH = h;
                newW = w;
            }
            if (h != newH && w != newW)
            {
                // Si las dimensiones cambiaron, se modifica la imagen
                Bitmap newImg = new Bitmap(img, newW, newH);
                Graphics g = Graphics.FromImage(newImg);
                g.InterpolationMode =
                  System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.DrawImage(img, 0, 0, newImg.Width, newImg.Height);
                return newImg;
            }
            else
                return img;
        }
    }
}