using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthorizedApp.DAL;
using AuthorizedApp.Models;
using AuthorizedApp.BLL;
using System.Web.Security;

namespace AuthorizedApp.Controllers
{
    public class UserController : Controller
    {
        DbORMContext entities = new DbORMContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
           
            User context = (User)this.Session["vault"];
             this.ViewData["users"] = context;
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username , string password ,string returnUrl)
        {
           
            bool status = AccountManager.IsValid(username, password);
            if(status)
            {
                
                User user=entities.User.SingleOrDefault(u => u.UserName == username);
                this.Session["vault"] = user;
               
                ViewData["user"] = user;
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));

            }
            
            return View();
        }

        public ActionResult Logout()
        {
            //DbORMContext context = (DbORMContext)this.Session["vault"];
            this.Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}