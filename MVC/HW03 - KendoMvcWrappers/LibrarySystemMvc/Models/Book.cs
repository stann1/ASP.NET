using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystemMvc.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        public string Description { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }
        public string Website { get; set; }

        public virtual Category Category { get; set; }
    }
}