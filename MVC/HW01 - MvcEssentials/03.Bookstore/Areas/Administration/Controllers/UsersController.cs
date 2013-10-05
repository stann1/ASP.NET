using _03.Bookstore.Areas.Administration.Models;
using _03.Bookstore.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.Bookstore.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        private List<UserViewModel> usersData;

        public UsersController()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            this.usersData = context.Users.Include("Roles").Select(u => new UserViewModel()
            {
                Id = u.Id,
                Username = u.UserName,
                Role = u.Roles.FirstOrDefault().Role.Name
            }).ToList();
        }
        
        [ActionName("All")]
        public ActionResult GetAll()
        {                        
            return View("GetAll", this.usersData);
        }

        public ActionResult EditUser(string id)
        {
            var user = this.usersData.FirstOrDefault(u => u.Id == id);
            return View(user);
        }
	}
}