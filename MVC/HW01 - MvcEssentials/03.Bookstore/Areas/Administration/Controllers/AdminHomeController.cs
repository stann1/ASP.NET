using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.Bookstore.Areas.Administration.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Administration/AdminHome/
        public ActionResult Index()
        {
            return View();
        }
	}
}