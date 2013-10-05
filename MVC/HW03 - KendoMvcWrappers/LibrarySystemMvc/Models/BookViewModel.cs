using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystemMvc.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }       
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Website { get; set; }
        public string CategoryName { get; set; }
    }
}