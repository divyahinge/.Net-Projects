using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Disney_HotstarApp.Models;

namespace Disney_HotstarApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            WatchList list = new WatchList();
            this.Session["movie"] = list;
        }

        protected void Session_Stop()
        {
            this.Session.Clear();
        }
    }
}
