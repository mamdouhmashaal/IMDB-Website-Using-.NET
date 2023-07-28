using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private Allmodel db = new Allmodel();

        public ActionResult Index()
        {
           Session["Userid"] = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string username = form["username"].ToString();
            string password = form["pass"].ToString();

            User user = db.User.Where(
                m => m.UserName == username && m.Password == password
                ).FirstOrDefault();

            if (user == null)
            {
                Session["Userid"] = "0";
                return View();
            }

            Session["Userid"] = user.UserId.ToString();

            return RedirectToAction("index", "Profile");
        }



        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FormCollection form, HttpPostedFileBase photo)
        {
            User user = new User();
            user.FirstName = form["Fname"].ToString();
            user.LastName = form["Lname"].ToString();
            user.UserName = form["username"].ToString();
            user.Password = form["pass"].ToString();

            HttpPostedFileBase postedFile = Request.Files["photo"];

            string path = Server.MapPath("~/Uploads/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));

            user.ProfileImage = "/Uploads/" + Path.GetFileName(postedFile.FileName);

            db.User.Add(user);
            db.SaveChanges();
            ViewBag.mss = "your acount is created ";

            return RedirectToAction("Index");
        }

    }
}