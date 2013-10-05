using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterApp.Repositories;

namespace TwitterApp.Controllers
{
    public class HomeController : BaseController
    {       
        public HomeController(IUowData context)
        {
            this.Data = context;
        }

        public HomeController() : this (new UowData())
        {

        }

        public ActionResult Index()
        {
            var topTweets = this.Data.Tweets.All().OrderByDescending(t => t.PostDate).Take(10);
            return View(topTweets.ToList());
        }

        public ActionResult Details(int id)
        {
            var tweet = this.Data.Tweets.GetById(id);
            return View(tweet);
        }

        public ActionResult SearchResult(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return View();
            }

            if (!searchString.StartsWith("#"))
            {
                searchString = "#" + searchString;
            }
            var existingTag = this.Data.Tags.All().FirstOrDefault(t => t.Name.ToLower() == searchString.ToLower());
            if (existingTag == null)
            {
                return View();
            }
            else
            {
                if (this.HttpContext.Cache["TweetsByTag"] == null)
                {
                    var tweets = this.Data.Tweets.All().Where(tweet => tweet.TagId == existingTag.Id);

                    this.HttpContext.Cache.Add("TweetsByTag", tweets.ToList(), null, DateTime.Now.AddMinutes(15), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
                }

                return View(this.HttpContext.Cache["TweetsByTag"]);
            }
        }
      
    }
}