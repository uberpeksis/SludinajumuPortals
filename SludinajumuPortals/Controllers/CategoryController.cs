using Logic;
using SludinajumuPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SludinajumuPortals.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        PostingsManager postingsManager = new PostingsManager();

        // GET: Category
        public ActionResult Index(int Id)
        {
            CategoryCatalogModel model = new CategoryCatalogModel();
            model.Categories = categoryManager.SelectAllCategoriesForHomePage();
            model.Postings = postingsManager.SelectAllPostingsByCategory(Id);

            model.ActiveCategory = model.Categories.Find(c => c.Id == Id);


            return View(model);
        }

        public ActionResult MyPostings()
        {
            CategoryCatalogModel model = new CategoryCatalogModel();
            model.Categories = categoryManager.SelectAllCategoriesForHomePage();
            model.Postings = postingsManager.SelectAllPostingsByUserId(Session.GetUser().Id);

            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            postingsManager.DeletePostingById(Id);

            TempData["Success"] = "Sludinājums ir dzēsts!";

            return RedirectToAction("MyPostings","Category");
        }
    }
}