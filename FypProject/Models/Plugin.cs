using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FypProject.Models
{
    public class Plugin
    {
        [Key]
        public int PluginID { get; set; }

        [Display(Name = "Item Level")]
        public items ItemLevel { get; set; }

        [Display(Name = "Item Category")]
        public plugin Category { get; set; }

        [Display(Name = "Item Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }

        [Display(Name = "Representative Photo")]
        public string ImageUrl { get; set; }


        [Display(Name = "Screen Shots")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        [NotMapped]
        [Display(Name = "Compatible Browsers")]
        public IList<SelectListItem> CompatibleBrowsers { get; set; }

        public layered Layered { get; set; }
        public layout Layout { get; set; }
        public highresolution HighResolution { get; set; }
        [Display(Name = "Demo Url")]
        public string LiveDemo { get; set; }
        public string Tags { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        [Required]
        public bool License { get; set; }


    }
    public enum plugin
    {
        HTML5,
        css,
        Mobile,
        Apps,
        dotNet,
        Plugin,
        JavaScript,
        php,
        Skins
    }
}
