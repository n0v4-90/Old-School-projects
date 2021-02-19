using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filmnettsted.Models;
using System.IO;


namespace Filmnettsted.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            try {
                var db = new FilmnettstedDBEntitties();
                {
                    var movieList = (from movies in db.Movie select movies).ToList();
                    return View(movieList);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Feilmelding = ex.Message;
                return View();
            }
          
        }

        //Registration
        public ActionResult Registrations()
        {
            return View();
        }

        //Registration
        [HttpPost]
        public ActionResult Registrations(Registration reg)
        {
            if (ModelState.IsValid)
            {
                var db = new FilmnettstedDBEntitties();
                {
                    db.Registration.Add(reg);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = reg.Firstname + " " + reg.Lastname + " " + "Succesesfully Registered.";
            }
            return View();
        }

        //login
        [HttpGet]
        public ActionResult Login()
        {
            if(Session["Username"]!= null)
            { 
                if((String)Session["Username"] == "admin")
                 {

                 }
                 String username = (String)Session["Username"];
            }
            return View();
        }

        //Login
        [HttpPost]
        public ActionResult Login(Registration reg)
        {
            try {
                var db = new FilmnettstedDBEntitties();
                {
                    var user = db.Registration.Where(u => u.Username == reg.Username && u.Password == reg.Password).FirstOrDefault();
                  
                    if (user != null || user == null)
                    {
                    Session["UserId"] = user.UserId.ToString();
                    Session["Username"] = user.Username.ToString();
                    ViewBag.Loggedin = true;
                    }
                    else
                    {
                     ViewBag.Loggedin = false;
                    }
                }
                return View();
           }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View();
            }
        }
       
        [HttpGet]
        public ActionResult MovieImages()
        {
           if (Session["Username"] != null)
           {
               
               
           }
           else
           {
               return RedirectToAction("Login");
           }
            return View();
        }
        [HttpPost]
        public ActionResult MovieImages(Movie newImage, HttpPostedFileBase file)
        { 
            if (file != null)
            {
                String fileName = Path.GetFileName(file.FileName);
                String filePath = Path.Combine(Server.MapPath("~/Image"), fileName);
                file.SaveAs(filePath);
                newImage.Image = fileName;

            }
            var db = new FilmnettstedDBEntitties();
            { 
            db.Movie.Add(newImage);
            db.SaveChanges();
            }
            return View(newImage);
        }
    }
}