using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterApp.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }
       
    }
}