using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORMBasedApp.Models;
using ORMBasedApp.DAL;
using System.Net;

namespace ORMBasedApp.Controllers
{
    public class FlowerController : Controller
    {
        // GET: Flower
        DbORMContext entities = new DbORMContext();
        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = entities.Book.ToList();
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = entities.Book.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            this.ViewData["book"] = book;
            return View();
        }

    }

}