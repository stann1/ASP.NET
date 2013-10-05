using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesCatalogue.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Director { get; set; }
        
        [Range(1900, 2050)]
        public int Year { get; set; }
        public string Studio { get; set; }
        public string StudioAddress { get; set; }
        public virtual Actor LeadingMale { get; set; }
        public virtual Actor LeadingFemale { get; set; }
    }
}