using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterApp.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^#\w{3,30}")]
        public string Name { get; set; }
    }
}