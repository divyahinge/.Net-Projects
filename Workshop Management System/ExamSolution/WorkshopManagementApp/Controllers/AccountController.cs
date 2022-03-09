using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkshopManagementApp.Models;
using WorkshopManagementApp.BLL;
using WorkshopManagementApp.DAL;
using System.Web.Security;

namespace WorkshopManagementApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        WorkDbContext entities = new WorkDbContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string id, string password, string returnUrl)
        {
            bool status = AccountManager.Validate(id, password);
            if (status)
            {
                FormsAuthentication.SetAuthCookie(id, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}