using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwitterApp.Models
{
    public class TweetViewModel
    {
        [Required]
        [StringLength(250)]
        [AllowHtml]
        public string Content { get; set; }        

        [Required]
        [RegularExpression(@"^#\w{3,30}", ErrorMessage="The tag name must start with '#' and be between 3 and 30 characters")]
        public string TagName { get; set; }
    }
}