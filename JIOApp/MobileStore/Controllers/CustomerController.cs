using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace MobileStore.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> cust = (List<Customer>)this.HttpContext.Application["user"];
            this.ViewData["customer"] = cust;
            return View();
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            Customer product = new Customer();
            return View(product);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer cust)
        {
            if (this.ModelState.IsValid)
            {
                List<Customer> prod = (List<Customer>)this.HttpContext.Application["user"];
                CustomerDAL.InsertCustomer(cust);
                prod.Add(cust);
                return RedirectToAction("Index", "customer");
            }
            else
            {
                return View(cust);
            }
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            List<Customer> prod = (List<Customer>)this.HttpContext.Application["user"];
            Customer pr = prod.Find((theProd) => theProd.Id == id);
            CustomerDAL.DeleteByCustomerId(id);
            prod.Remove(pr);
            return RedirectToAction("Index", "Customer");
        }
    }
}