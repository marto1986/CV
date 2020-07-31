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
    public class PDFController : Controller
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult Index()
        {
            try
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

                #region Invocamos Datos Personales
                var requestDatosPersonales = clienteHttp.GetAsync("api/DatosPersonales").Result;
                if (requestDatosPersonales.IsSuccessStatusCode)
                {
                    var resultStringDatosPersonales = requestDatosPersonales.Content.ReadAsStringAsync().Result;
                    var listadoDatosPersonales = JsonConvert.DeserializeObject<List<DatosPersonalesDTO>>(resultStringDatosPersonales);

                    if (ViewBag.ObjUsuario != null)
                    {
                        var DatosPersonales = listadoDatosPersonales.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                        ViewBag.DatosPersonales = DatosPersonales;
                    }
                }
                #endregion

                #region Invocamos Educación
                var requestEducacion = clienteHttp.GetAsync("api/Educacion").Result;

                if (requestEducacion.IsSuccessStatusCode)
                {
                    var resultStringEducacion = requestEducacion.Content.ReadAsStringAsync().Result;
                    var listadoEducacion = JsonConvert.DeserializeObject<List<EducacionDTO>>(resultStringEducacion);

                    if (ViewBag.ObjUsuario != null)
                    {
                        var resultadorequestEducacion = listadoEducacion.Where(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                        ViewBag.requestEducacion = resultadorequestEducacion;
                    }
                }
                #endregion

                #region Invocamos Experiencia Laboral
                var requestExperienciaLaboral = clienteHttp.GetAsync("api/ExperienciaLaboral").Result;

                if (requestExperienciaLaboral.IsSuccessStatusCode)
                {
                    var resultStringExperienciaLaboral = requestExperienciaLaboral.Content.ReadAsStringAsync().Result;
                    var listadoExperienciaLaboral = JsonConvert.DeserializeObject<List<ExperienciaLaboralDTO>>(resultStringExperienciaLaboral);
                    if (ViewBag.ObjUsuario != null)
                    {
                        var resultadoExperienciaLaboral = listadoExperienciaLaboral.Where(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                        ViewBag.ExperienciaLaboral = resultadoExperienciaLaboral;
                    }

                }
                #endregion

                #region Invocamos Idioma
                var requestIdioma = clienteHttp.GetAsync("api/Idioma").Result;

                if (requestIdioma.IsSuccessStatusCode)
                {
                    var resultStringIdioma = requestIdioma.Content.ReadAsStringAsync().Result;
                    var listadoIdioma = JsonConvert.DeserializeObject<List<IdiomaDTO>>(resultStringIdioma);
                    if (ViewBag.ObjUsuario != null)
                    {
                        var resultadoIdioma = listadoIdioma.Where(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                        ViewBag.Idioma = resultadoIdioma;
                    }
                }
                #endregion

                #region Invocamos Conocimientos
                var requestConocimiento = clienteHttp.GetAsync("api/Conocimiento").Result;

                if (requestConocimiento.IsSuccessStatusCode)
                {
                    var resultStringConocimiento = requestConocimiento.Content.ReadAsStringAsync().Result;
                    var listadoConocimiento = JsonConvert.DeserializeObject<List<ConocimientoDTO>>(resultStringConocimiento);
                    if (ViewBag.ObjUsuario != null)
                    {
                        var resultadoConocimiento = listadoConocimiento.Where(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                        ViewBag.Conocimiento = resultadoConocimiento;
                    }
                }
                #endregion

                #region Invocamos Objetivo
                var requestObjetivo = clienteHttp.GetAsync("api/Objetivo").Result;

                if (requestObjetivo.IsSuccessStatusCode)
                {
                    var resultStringObjetivo = requestObjetivo.Content.ReadAsStringAsync().Result;
                    var listadoObjetivo = JsonConvert.DeserializeObject<List<ObjetivoDTO>>(resultStringObjetivo);
                    var resultadoObjetivo = listadoObjetivo.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);

                    ViewBag.Objetivo = resultadoObjetivo;
                }
                #endregion

                #region Invocamos la imagen
                var requestImagen = clienteHttp.GetAsync("api/Imagen").Result;

                if (requestImagen.IsSuccessStatusCode)
                {
                    var resultStringImagen = requestImagen.Content.ReadAsStringAsync().Result;
                    var listadoImagen = JsonConvert.DeserializeObject<List<ImagenDTO>>(resultStringImagen);
                    if (ViewBag.ObjUsuario != null)
                    {
                        var resultadoImagen = listadoImagen.FirstOrDefault(x => x.UsuarioId == ViewBag.ObjUsuario.UsuarioId);
                        ViewBag.Imagen = resultadoImagen;
                    }
                }
                #endregion

                return View();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }
    }
}