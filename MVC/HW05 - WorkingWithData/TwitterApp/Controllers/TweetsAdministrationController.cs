using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitterApp.Models;

namespace TwitterApp.Controllers
{
    [Authorize]
    //[Authorize(Roles = "Admin")]
    public class TweetsAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const int PageSize = 10;

        // GET: /TweetsAdministration/
        public ActionResult Index(int? id)
        {
            var pageNum = id.GetValueOrDefault(1);
            var tweets = db.Tweets.Include(t => t.Creator).Include(t => t.Tag);
            var selected = tweets.OrderBy(t => t.PostDate).Skip((pageNum - 1) * PageSize).Take(PageSize);

            ViewBag.Pages = Math.Ceiling((double)tweets.Count() / PageSize);
            return View(selected.ToList());
        }

        // GET: /TweetsAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: /TweetsAdministration/Create
        public ActionResult Create()
        {
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name");
            return View();
        }

        // POST: /TweetsAdministration/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Tweets.Add(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatorId = new SelectList(db.Users, "Id", "UserName", tweet.CreatorId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", tweet.TagId);
            return View(tweet);
        }

        // GET: /TweetsAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "UserName", tweet.CreatorId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", tweet.TagId);
            return View(tweet);
        }

        // POST: /TweetsAdministration/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tweet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "UserName", tweet.CreatorId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", tweet.TagId);
            return View(tweet);
        }

        // GET: /TweetsAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.Find(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /TweetsAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            db.Tweets.Remove(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
