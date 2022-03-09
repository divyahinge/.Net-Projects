using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Disney_HotstarApp.Models;

namespace Disney_HotstarApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            WatchList watchList = (WatchList) this.Session["movie"];
            ViewBag.WatchList = watchList;
            return View();
        }

        [HttpGet]
        public ActionResult AddToWatchlist(int id, string name)
        {
            Feedback bk = new Feedback();
            bk.Id = id;
            bk.Name = name;
            bk.Review = "";
            ViewBag.feedback = bk;
            return View();
        }

        [HttpPost]
        public ActionResult AddToWatchlist(int id, string name, string review)
        {
            Feedback bk = new Feedback();
            bk.Id = id;
            bk.Name = name;
            bk.Review = review;

            WatchList watchList = (WatchList)this.Session["movie"];
            watchList.AddFeedback(bk);
            ViewBag.feedback = bk;
            return RedirectToAction("Index" , "movie");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            WatchList watchList = (WatchList)this.Session["movie"];
            List<Feedback> allItems = watchList.GetAllMovies();
            Feedback foundItem = allItems.Find((theItem) => theItem.Id == id);
            ViewBag.feedback = foundItem;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, string name, string review)
        {
            //update item into Shoppingcart instance

            WatchList watchList = (WatchList)this.Session["movie"];
            List<Feedback> allItems = watchList.GetAllMovies();
            Feedback foundItem = allItems.Find((theItem) => theItem.Id == id);

            //Replace existing quantity with posted quantity
            foundItem.Name = name;
            foundItem.Review = review;
            watchList.UpdateFeedback(foundItem);
            return RedirectToAction("Index", "movie");
        }

        public ActionResult Remove(int id)
        {
            WatchList watchList = (WatchList)this.Session["movie"];
            List<Feedback> allItems = watchList.GetAllMovies();
            Feedback foundItem = allItems.Find((theItem) => theItem.Id == id);
            allItems.Remove(foundItem);
            return RedirectToAction("Index", "movie");

        }
    }
}