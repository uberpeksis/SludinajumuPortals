using Logic;
using Logic.Data;
using SludinajumuPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SludinajumuPortals.Controllers
{
    public class UserController : Controller
    {
        UserManager manager = new UserManager();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserData user = manager.SelectByUsernameAndPassword(model.Username, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("user", "Nepareizs lietotājsvārds un/vai parole!");
                }
                else
                {
                    Session.SetUser(user); 
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserData user = manager.SelectByUsername(model.Username);
                if (user != null)
                {
                    ModelState.AddModelError("user", "Šāds lietotājs jau eksistē!");
                }
                else
                {
                    manager.Create(model.Username, model.Password);
                    return RedirectToAction("Login", "User");
                }

            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}