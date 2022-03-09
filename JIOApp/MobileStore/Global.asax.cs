using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BOL;
using DAL;

namespace MobileStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            List<Product> pr = ProductDAL.getAllProduct();
            HttpContext.Current.Application.Add("store", pr);
            List<Customer> cust = CustomerDAL.GetAllCustomer();
            HttpContext.Current.Application.Add("user",cust );
            List<Company> comp = CompanyDAL.getAllCompanies();
            HttpContext.Current.Application.Add("expo", comp);
        }
    }
}
