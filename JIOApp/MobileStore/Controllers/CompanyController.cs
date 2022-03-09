using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace MobileStore.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            List<Company> comp = this.HttpContext.Application["expo"] as List<Company>;
            ViewData["company"] = comp;
            return View();
        }


        [HttpGet]
        public ActionResult AddCompany()
        {
            Company company = new Company();
            return View(company);
        }

        [HttpPost]
        public ActionResult AddCompany(Company comp)
        {
            if (this.ModelState.IsValid)
            {
                List<Company> prod = (List<Company>)this.HttpContext.Application["expo"];
                CompanyDAL.InsertCompany(comp);
                prod.Add(comp);
                return RedirectToAction("Index", "company");
            }
            else
            {
                return View(comp);
            }
        }
    }
}