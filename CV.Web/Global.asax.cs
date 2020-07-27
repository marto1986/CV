using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CV.Web.Controllers;

namespace CV.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
            HttpException httpException = ex as HttpException;

            string accion = "";

            switch(httpException.GetHttpCode())
            {
                case 404:
                    accion = "Error404";
                    break;
                case 500:
                    accion = "Error500";
                    break;
                default:
                    accion = "ErrorGeneral";
                    break;
            }

            Context.ClearError();
            RouteData rutaError = new RouteData();

            rutaError.Values.Add("Controller", "Error");
            rutaError.Values.Add("action", accion);

            IController controlador = new ErrorController();
            controlador.Execute(
                    new RequestContext(new HttpContextWrapper(Context), rutaError)
                );
        }
    }
}
