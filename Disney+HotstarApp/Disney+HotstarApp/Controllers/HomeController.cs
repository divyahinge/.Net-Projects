using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disney_HotstarApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tv()
        {
            return View();
        }

        public ActionResult Movies()
        {
            return View();
        }

        public ActionResult Sports()
        {
            return View();
        }
    }
}