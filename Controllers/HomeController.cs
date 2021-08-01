﻿using SuperMerk2.Business;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
            CategoriaBL biz = new CategoriaBL();
            var product = biz.GetAll();
            return View(product);
        }
    }
}
