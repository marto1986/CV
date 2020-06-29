﻿using System.Web;
using System.Web.Mvc;

namespace CV.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerificarSesion());
        }
    }
}
