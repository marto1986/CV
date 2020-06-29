using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Web.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesion
        public ActionResult LoginOff()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Usuario");
        }
    }
}