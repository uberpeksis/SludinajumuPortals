using Logic;
using SludinajumuPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SludinajumuPortals.Controllers
{
    public class HomeController : Controller
    {
        CategoryManager categories = new CategoryManager();

        public ActionResult Index()
        {
            CategoryCatalogModel model = new CategoryCatalogModel();

            model.Categories = categories.SelectAllCategoriesForHomePage();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}