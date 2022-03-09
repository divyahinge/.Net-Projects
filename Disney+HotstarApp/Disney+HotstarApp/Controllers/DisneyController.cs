using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Disney_HotstarApp.Models;

namespace Disney_HotstarApp.Controllers
{
    public class DisneyController : Controller
    {
        // GET: Disney
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Imdb im = null;
            switch(id)
            {
                case 1:
                    im = new Imdb
                    {
                        Id = 1,
                        Name = "Cruella",
                        Genre = "Crime",
                        ImagUrl = "/images/cruella.jpg",
                        YearOfRelease = "2021",
                        Rating = "****",
                        Review = "Good"
                    };
                    break;

                case 2:
                    im = new Imdb
                    {
                        Id = 2,
                        Name = "Aladin",
                        Genre = "Comedy",
                        ImagUrl = "/images/aladin.jpg",
                        YearOfRelease = "2020",
                        Rating = "***",
                        Review = "Nice"
                    };
                    break;

                case 3:
                    im = new Imdb
                    {
                        Id = 3,
                        Name = "Mulan",
                        Genre = "Action",
                        ImagUrl = "/images/mulan.jpg",
                        YearOfRelease = "2021",
                        Rating = "*****",
                        Review = "Awesome"
                    };
                    break;
            }
            this.ViewBag.movie = im;
            return View();
        }
    }
}