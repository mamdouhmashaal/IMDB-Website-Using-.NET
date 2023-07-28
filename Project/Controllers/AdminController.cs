using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        private Allmodel db = new Allmodel();
        // GET: Admin
        public ActionResult Index()
        {
            Session["UserId"] = "0";
            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string Username = form["username"].ToString();
            string Password = form["pass"].ToString();

            if (Username == "admin" && Password == "admin")
            {
                Session["UserId"] = "1";
            }
            return RedirectToAction("AdminActions", "Admin");
        }

        public ActionResult AdminActions()
        {
            if (Session["UserId"] == "0")
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        public ActionResult Addmovie()
        {
            if (Session["UserId"] == "0" || Session["UserId"] == null || Session["UserId"] != "1")
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Addmovie(FormCollection form, HttpPostedFileBase photo)
        {
            Movie movie = new Movie();

            movie.MovieName = form["name"].ToString();
            movie.MovieActors = form["actorsname"].ToString();
            movie.MovieDirectors = form["directorname"].ToString();

            HttpPostedFileBase postedFile = Request.Files["photo"];
            if (postedFile != null)
            {
                string path = Server.MapPath("~/movie/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
            }
            movie.MovieImage = "/movie/" + Path.GetFileName(postedFile.FileName);
            db.Movie.Add(movie);
            db.SaveChanges();
            return View();
        }

        public ActionResult AddActor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddActor(FormCollection form)
        {

            return View();
        }

        public ActionResult AllMovie()
        {
            return View(db.Movie.ToList());
        }


        public ActionResult AddActorToMovie()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddActorToMovie(FormCollection form)
        {
            return View();
        }

    }
}
