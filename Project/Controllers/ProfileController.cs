using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == "0" && Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}