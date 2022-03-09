using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthorizedApp.DAL;
using AuthorizedApp.Models;

namespace AuthorizedApp.Controllers
{
    public class AccountController : Controller
    {
        DbORMContext entities = new DbORMContext();

        // GET: Account
        public ActionResult Index()
        {
            List<User> users =entities.User.ToList();
            this.ViewData["users"] = users;
            return View();
        }

       

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if(ModelState.IsValid)
            {
                entities.User.Add(user);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

       
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var user = entities.User.SingleOrDefault(u=>u.Id==id);
            if(user == null)
            {
                return new HttpNotFoundResult();
            }
            this.ViewData["user"] = user;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if(ModelState.IsValid)
            {
                entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
               
                return RedirectToAction("Details", "User");
            }
            return View();
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            User user = entities.User.SingleOrDefault(u => u.Id == id);
            entities.User.Remove(user ?? throw new InvalidOperationException());
            entities.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}