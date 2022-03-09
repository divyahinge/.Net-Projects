using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AuthorizedApp.Models;
using AuthorizedApp.DAL;

namespace AuthorizedApp
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
            //DbORMContext context = new DbORMContext();
            User context = new User();
            this.Session["vault"] = context;
        }

        protected void Session_Stop()
        {

            this.Session.Clear();
        }
    }
}
