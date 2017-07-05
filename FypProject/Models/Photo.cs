using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FypProject.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }

        [Display(Name = "Item Level")]
        public itemz ItemLevel { get; set; }

        [Display(Name = "Item Category")]
        public photo Category { get; set; }

        [Display(Name = "Item Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }

        public layered Layered { get; set; }
        public layout Layout { get; set; }
        public highresolution HighResolution { get; set; }

        [Display(Name = "Photoshot VideoLink")]
        public string VideoUrl { get; set; }
        public string Tags { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        [Required]
        public bool License { get; set; }


    }
    public enum photo
    {
        People,
        Animals,
        Animated,
        Action,
        Nature,
        Other

    }

    public enum itemz
    {
        Beginner,
        Professional
        
    }
 

}
