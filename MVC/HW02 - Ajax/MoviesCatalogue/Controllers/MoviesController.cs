using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesCatalogue.Models;

namespace MoviesCatalogue.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: /Movies/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                UpdateActors(movie);
                
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        
        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Include("LeadingMale").Include("LeadingFemale").FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", movie);
        }

        // POST: /Movies/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {                
                //db.Entry(movie).State = EntityState.Modified;

                var existingMovie = db.Movies.Find(movie.Id);
                existingMovie.Title = movie.Title;
                existingMovie.Director = movie.Director;
                existingMovie.Studio = movie.Studio;
                existingMovie.StudioAddress = movie.StudioAddress;
                existingMovie.Year = movie.Year;

                UpdateActors(movie);
                existingMovie.LeadingMale = movie.LeadingMale;
                existingMovie.LeadingFemale = movie.LeadingFemale;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("Edit", movie);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void UpdateActors(Movie movie)
        {
            if (movie.LeadingMale != null)
            {
                string actorName = movie.LeadingMale.Name;
                var existingActor = db.Actors.FirstOrDefault(a => a.Name == actorName);
                if (existingActor != null)
                {
                    movie.LeadingMale = existingActor;
                }
            }
            if (movie.LeadingFemale != null)
            {
                string actorName = movie.LeadingFemale.Name;
                var existingActor = db.Actors.FirstOrDefault(a => a.Name == actorName);
                if (existingActor != null)
                {
                    movie.LeadingFemale = existingActor;
                }
            }
        }
    }
}
