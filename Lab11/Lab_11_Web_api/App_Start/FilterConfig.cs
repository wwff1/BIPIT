﻿using System.Web;
using System.Web.Mvc;

namespace Lab_11_Web_api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
