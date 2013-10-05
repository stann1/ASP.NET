using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterApp.Repositories;

namespace TwitterApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IUowData Data { get; set; }

        public BaseController(IUowData dataContext)
        {
            this.Data = dataContext;
        }

        public BaseController() : this(new UowData())
        {

        }
	}
}