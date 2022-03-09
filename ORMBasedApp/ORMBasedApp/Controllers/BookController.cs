using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ORMBasedApp.DAL;
using ORMBasedApp.Models;
using System.Net;

namespace ORMBasedApp.Controllers
{
    public class BookController : Controller
    {
        DbORMContext entities = new DbORMContext();
        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = entities.Book.ToList();
            this.ViewData["books"] = books;
            return View();
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = entities.Book.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            this.ViewData["book"] = book;
            return View();
        }

        public ActionResult Delete(int? id)
        {
            Book book = entities.Book.SingleOrDefault(b => b.Id == id);
            entities.Book.Remove(book ?? throw new InvalidOperationException());
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = entities.Book.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if(this.ModelState.IsValid)
            {
                entities.Entry(book).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(Book book)
        {
            if(ModelState.IsValid)
            {
                entities.Book.Add(book);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}