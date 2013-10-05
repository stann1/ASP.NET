using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TwitterApp.Models;

namespace TwitterApp.Controllers
{
    [Authorize]
    public class UserProfileController : BaseController
    {        
        public ActionResult MyTweets()
        {
            var currentUserId = User.Identity.GetUserId();
            var myTweets = this.Data.Tweets.All().Where(tw => tw.CreatorId == currentUserId);
            return View(myTweets.ToList());
        }

        [HttpGet]
        public ActionResult CreateTweet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTweet(TweetViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var existingTag = this.Data.Tags.All().FirstOrDefault(tag => tag.Name == tweet.TagName);
                if (existingTag == null)
                {
                    existingTag = new Tag() { Name = tweet.TagName };
                }

                Tweet newTweet = new Tweet()
                {
                    Content = tweet.Content,
                    PostDate = DateTime.Now,
                    CreatorId = currentUserId,
                    Tag = existingTag
                };

                this.Data.Tweets.Add(newTweet);
                this.Data.SaveChanges();

                return RedirectToAction("MyTweets");
            }
            else
            {
                return View(tweet);
            }
        }
	}
}