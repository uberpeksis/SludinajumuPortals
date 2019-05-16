using Logic;
using Logic.Data;
using SludinajumuPortals.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SludinajumuPortals.Controllers
{
    public class PostingsController : Controller
    {
        NewPostingsManager manager = new NewPostingsManager();
        CategoryManager categoryManager = new CategoryManager();
        PostingsManager postingsManager = new PostingsManager();

        // GET: Postings
        public ActionResult Index(int Id)
        {
            CategoryCatalogModel model = new CategoryCatalogModel();
            model.Categories = categoryManager.SelectAllCategoriesForHomePage();
            model.ActivePosting = postingsManager.SelectPostingById(Id);
            model.ActiveCategory = categoryManager.SelectCategoryById(model.ActivePosting.CategoryId);

            return View(model);
        }

        //Get: NewPostings
        public ActionResult NewPostings()
        {
            NewPostingsModel model = new NewPostingsModel();
            model.Categories = categoryManager.SelectAllCategoriesForNewPostings();

            return View(model);
        }

        [HttpPost]
        public ActionResult NewPostings(NewPostingsModel model)
        {
            model.Categories = categoryManager.SelectAllCategoriesForNewPostings();
            if (ModelState.IsValid)
            {
                string image = "";
                foreach (var posting in model.Image)
                {
                    if (posting != null)
                    {
                        if (posting.ContentLength > 0)
                        {
                            if (Path.GetExtension(posting.FileName).ToLower() == ".jpg"
                                || Path.GetExtension(posting.FileName).ToLower() == ".png"
                                || Path.GetExtension(posting.FileName).ToLower() == ".gif"
                                || Path.GetExtension(posting.FileName).ToLower() == ".jpeg")
                            {
                                string random = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                                string path = Path.Combine(Server.MapPath("~/Content/Images"), random + posting.FileName);
                                posting.SaveAs(path);

                                path = "~/Content/Images/" + random + posting.FileName;
                                image += path + ";";
                            }
                        }
                    }
                }
                manager.CreateNewPostings(model.CategoryId, model.Title, model.Price, model.Adress, image, model.Phone, model.Email, model.Description, Session.GetUser().Id);
                TempData["Success"] = "Sludinājums ir pievienots!";
                return RedirectToAction("NewPostings");
            }
            return View(model);
        }
    }
}
