using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filmnettsted.Models;
using System.IO;

namespace Filmnettsted.Controllers
{
    public class AdminController : Controller
    {
        private FilmnettstedDBEntitties db = new FilmnettstedDBEntitties();

        // GET: Admin
        public ActionResult Index()
        {
            try
            {
                var db = new FilmnettstedDBEntitties();
                {
                    var movie = (from movieList in db.Movie select movieList).ToList();
                    return View(movie);
                }
            }
            catch(Exception exception)
            {
                ViewBag.errorMessage = exception.Message;
                return View();
            }
            
        }

        public ActionResult seeRegisteredUser()
        {
            try
            {
                var db = new FilmnettstedDBEntitties();
                {
                    var user = (from userList in db.Registration select userList).ToString();
                    return View(ToString());
                }
            }catch(Exception ex)
            {
                ViewBag.SuccesesfullyDeleted = ex.Message;
                return View();
            }
        }

        public ActionResult Create()
        {
            var db = new FilmnettstedDBEntitties();
            { 

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Genre");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Language");
            return View();

            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Title,Releasedate,Description,Image,GenreId,LanguageId,Duration")] Movie movie)
        {

            var db = new FilmnettstedDBEntitties();
            { 
            if (ModelState.IsValid)
            {
                db.Movie.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Genre", movie.GenreId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Language", movie.LanguageId);
            return View(movie);
            }
        }
        
        public ActionResult Edit(int? id)
        {
            var db = new FilmnettstedDBEntitties();
            { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Genre", movie.GenreId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Language", movie.LanguageId);
            return View(movie);
            }
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,Releasedate,Description,Image,GenreId,LanguageId,Duration")] Movie movie)
        {
            var db = new FilmnettstedDBEntitties();
            { 
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


           ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Genre", movie.GenreId);
           ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Language", movie.LanguageId);
            return View(movie);
           }
        }

        public ActionResult Delete(int? id)
        {
            var db = new FilmnettstedDBEntitties();
            { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movie.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var db = new FilmnettstedDBEntitties();
            {
            Movie movie = db.Movie.Find(id);
            db.Movie.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult MovieImages()
        {
           // if (Session["Username"] != null)
           // {


          //  }
           // else
            //{
               // return RedirectToAction("Login");
           // }
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
                ViewBag.Path = "image uploaded Successfully...!";
            }
            return View(newImage);
        }
    }
}