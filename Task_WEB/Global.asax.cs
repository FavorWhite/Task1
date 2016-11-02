using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Task1_BLL.Configuration;

namespace Task_WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

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
