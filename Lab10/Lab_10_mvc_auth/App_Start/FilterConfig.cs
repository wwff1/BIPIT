﻿using System.Web;
using System.Web.Mvc;

namespace Lab_10_mvc_auth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
