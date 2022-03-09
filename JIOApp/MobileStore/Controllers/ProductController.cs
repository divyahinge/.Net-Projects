using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;

namespace MobileStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> prod = (List<Product>)this.HttpContext.Application["store"];
            this.ViewData["product"] = prod;
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult AddProduct(Product pr)
        {
            if(this.ModelState.IsValid)
            {
                List<Product> prod = (List<Product>)this.HttpContext.Application["store"];
                ProductDAL.insertProduct(pr);
                prod.Add(pr);
                return RedirectToAction("Index", "product");
            }
            else
            {
                return View(pr);
            }          
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Product> prod = (List<Product>)this.HttpContext.Application["store"];
            Product pr = prod.Find((theProd) => theProd.Id == id);

            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(this.ModelState.IsValid)
            {
                //List<Product> prod = (List<Product>)this.HttpContext.Application["store"];
                //Product pr = prod.Find((p) => p.Id == product.Id);
                //prod.Remove(pr);
                ProductDAL.updateProduct(product);
                //prod.Add(product);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(product);
            }            
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            List<Product> prod = (List<Product>)this.HttpContext.Application["store"];
            Product pr = prod.Find((theProd) => theProd.Id == id);
            ProductDAL.deleteById(id);
            prod.Remove(pr);
            return RedirectToAction("Index","Product");
        }
    }
}