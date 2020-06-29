using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.Entidades;
using CV.Web.Controllers;

namespace CV.Web.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = (UsuarioDTO)HttpContext.Current.Session["Usuario"];

            if(usuario == null)
            {
                if(filterContext.Controller is UsuarioController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Usuario/Index");
                }
            }
            else
            {
                if (filterContext.Controller is UsuarioController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/DatosPersonales/Nuevo");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}