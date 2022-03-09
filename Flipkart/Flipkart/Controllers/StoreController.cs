using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flipkart.Models;

namespace Flipkart.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            Store theStore = (Store)this.Session["store"];
            //List<Item> list = theStore.GetAllItems();
            ViewBag.items = theStore;
            return View();
        }

        [HttpGet]
        public ActionResult AddToStore(int id)
        {
            Item item = new Item();
            item.Id = id;
            item.Quantity = 0;
            ViewBag.item = item;
            return View();
        }

        [HttpPost]
        public ActionResult AddToStore(int id,int quantity)
        {
            Item item = new Item();
            item.Id = id;
            item.Quantity = quantity;
            Store theStore = (Store)this.Session["store"];
          
            theStore.InsertItem(item);
            return RedirectToAction("Index", "store");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Store theStore = (Store)this.Session["store"];
            Item item = theStore.FindItem(id);
            ViewBag.item = item;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, int quantity)
        {
            Store theStore = (Store)this.Session["store"];
            theStore.UpdateItem(id, quantity);
            return RedirectToAction("Index", "store"); 
        }

        public ActionResult Remove(int id)
        {
            Store theStore = (Store)this.Session["store"];
            //Item item = theStore.FindItem(id);
            theStore.DeleteItem(id);
            return RedirectToAction("Index", "store");
        }
    }
}