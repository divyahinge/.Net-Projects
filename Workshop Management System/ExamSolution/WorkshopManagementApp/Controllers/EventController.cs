using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkshopManagementApp.Models;
using WorkshopManagementApp.Controllers;
using WorkshopManagementApp.DAL;
using System.Net;

namespace WorkshopManagementApp.Controllers
{
    public class EventController : Controller
    {
        WorkDbContext entities = new WorkDbContext();

        public ActionResult Index()
        {
            List<Workshop> shop = entities.Workshops.ToList();
            this.ViewData["shop"] = shop;
            return View();
        }
        // GET: Account
        public ActionResult Details(int? id)
        {
           
            List<Workshop> shop = entities.Workshops.ToList();
            Workshop foundshop = shop.Find((shop1) => shop1.Id == id);

            this.ViewData["shop"] = foundshop;
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            //Workshop shop = new Workshop();
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                entities.Workshops.Add(workshop);
                entities.SaveChanges();
                return RedirectToAction("index");
            }


            return View(workshop);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var workshop = entities.Workshops.SingleOrDefault(u => u.Id == id);
            if (workshop == null)
            {
                return new HttpNotFoundResult();
            }
            this.ViewData["workshop"] = workshop;
            return View(workshop);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                entities.Entry(workshop).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();

                return RedirectToAction("Index", "Event");
            }
            return View();
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            
            Workshop workshop = entities.Workshops.SingleOrDefault(u => u.Id == id);
            entities.Workshops.Remove(workshop ?? throw new InvalidOperationException());
            entities.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}