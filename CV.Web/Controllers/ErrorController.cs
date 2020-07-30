using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace CV.Web.Controllers
{
    public class ErrorController : Controller
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Error
        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult Error500()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Error: {0}{1}", ex.StackTrace, ex.Message);
            }

            return View();
        }

        public ActionResult ErrorGeneral()
        {
            return View();
        }
    }
}