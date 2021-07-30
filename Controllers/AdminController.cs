using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            RedirectLogin();
            return View();
        }

        private void RedirectLogin()
        {
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
        }
    }
}
