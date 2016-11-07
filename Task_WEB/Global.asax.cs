﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Task1_BLL.Configuration;
using Task_WEB.App_Start;

namespace Task_WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperInit.Init();
        }
    }

    public static class MapperInit
    {
        public static void Init()
        {
            Mapper.Initialize(x => x.AddProfile(new MappingBLLProfile()));
        }
    }
}
