using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystemMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace LibrarySystemMvc.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Books/
        public ActionResult Index()
        {
            //var books = db.Books.Include("Category").ToList().Select(book => new BookViewModel()
            //{
            //    Id = book.Id,
            //    Title = book.Title,
            //    Author = book.Author,
            //    ISBN = book.ISBN,
            //    Website = book.Website,
            //    Description = book.Description,
            //    CategoryName = book.Category.Title
            //});
            var books = db.Books.Include("Category").ToList();   

            return View(books);
        }

        //
        // GET: /Books/Details/5
        public ActionResult Details(int id)
        {
            var book = db.Books.Find(id);
            return View(book);
        }

        //
        // GET: /Books/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Books/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                var cat = db.Categories.FirstOrDefault(c => c.Title == book.Category.Title);
                book.Category = cat;
                db.Books.Add(book);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include("Category").FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        
        //
        // POST: /Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(movie).State = EntityState.Modified;

                var existingBook = db.Books.Find(book.Id);
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Website = book.Website;
                existingBook.Description = book.Description;
                var cat = db.Categories.FirstOrDefault(c => c.Title == book.Category.Title);
                existingBook.Category = cat;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: /Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateCategories()
        {
            var categories = db.Categories
                        .Select(c => new CategoryViewModel
                        {
                            Id = c.Id,
                            Title = c.Title
                        })
                        .OrderBy(e => e.Title);
            ViewData["categories"] = categories;
            ViewData["defaultCategory"] = categories.First();
        }
    }
}
