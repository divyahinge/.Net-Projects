using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Flipkart.Models;

namespace Flipkart
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            
        }

        protected void Session_Start()
        {
            Store theStore = new Store();
            this.Session["store"] = theStore;
        }

        protected void Session_End()
        {
            this.Session.Clear();
        }

    }
}
