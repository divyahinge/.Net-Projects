using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace MobileStore.Controllers
{
    public class PortalController : Controller
    {
        // GET: Portal
        public ActionResult Index(int id)
        {
            List<Company> comp = this.HttpContext.Application["expo"] as List<Company>;
            Company c =comp.Find((theComp) => theComp.CompanyId == id);
            List<Customer> cust = this.HttpContext.Application["user"] as List<Customer>;
            Customer customer = cust.Find((e) => e.Product == c.CompanyProduct);
            List<Product> prod = this.HttpContext.Application["store"] as List<Product>;
            Product pr = prod.Find((e) => e.Title== customer.Product);
            this.ViewBag.product = pr;
            this.ViewBag.customer = customer;
            return View(c);
        }
    }
}