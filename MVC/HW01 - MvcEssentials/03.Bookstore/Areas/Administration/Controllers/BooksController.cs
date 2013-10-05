using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03.Bookstore.Models;

namespace _03.Bookstore.Areas.Administration.Controllers
{
    public class BooksController : Controller
    {
        private List<BookModel> bookData;

        public BooksController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            this.bookData = context.Books.OrderBy(b => b.Title).ToList();
        }

        public ActionResult GetAll()
        {            
            return View(this.bookData);
        }

        public ActionResult EditBook(int id)
        {
            var book = this.bookData.FirstOrDefault(b => b.Id == id);
            ViewBag.SelectedBook = book;

            return View("GetAll", bookData);
        }
	}
}