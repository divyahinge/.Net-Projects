using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flipkart.Models;

namespace Flipkart.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            Product prod = new Product();
            switch(id)
            {
                case 1:prod = new Product { Id = 1,
                    Name = "Jorden",
                    ImageUrl = "/images/shoe.jpg",
                    Info = "Extra Comfort",
                    Quantity = 1,
                    Price = 1
                };
                    
                    break;
            }
            ViewBag.product = prod;
            return View();
        }
    }
}