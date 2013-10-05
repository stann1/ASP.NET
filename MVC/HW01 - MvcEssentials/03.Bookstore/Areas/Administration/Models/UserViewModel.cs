using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03.Bookstore.Areas.Administration.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}