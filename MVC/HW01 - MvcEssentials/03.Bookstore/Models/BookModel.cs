﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03.Bookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Website { get; set; }

    }
}