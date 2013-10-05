using LibrarySystemMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemMvc.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        //
        // GET: /Categories/
        public JsonResult GetAll()
        {           
            var categories = db.Categories.ToList().Select(cat => new CategoryViewModel()
                {
                    Id = cat.Id,
                    Title = cat.Title
                });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Categories/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        //
        // POST: /Categories/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {            
            try
            {
                var existingCat = db.Categories.FirstOrDefault(c => c.Title == category.Title);
                if (existingCat != null)
                {
                    return Content("A category with this name already exist!");
                }

                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView("_Create");
            }
        }

        // GET: /Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", category);
        }

        // POST: /Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}