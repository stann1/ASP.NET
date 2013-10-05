using Kendo.Mvc.UI;
using LibrarySystemMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemMvc.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var autocompleteData = db.Books.Include("Category").ToList().Select(b => new BookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                CategoryName = b.Category.Title
            });

            var data = db.Categories.Include("Books").ToList().Select(item => new TreeViewItemModel()
            {
                Text = item.Title,
                Items = item.Books.Select(b => new TreeViewItemModel()
                {
                    Text = b.Title,
                    Url = "Books/Details/" + b.Id
                }).ToList(),
                
            });

            ViewBag.AllBooks = autocompleteData;

            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}