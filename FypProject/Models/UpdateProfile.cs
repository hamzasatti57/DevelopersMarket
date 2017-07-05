using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FypProject.Models
{
    public class UpdateProfile
    {
        [Key]
        public int DeveloperID { get; set; }

        [Required]
        public string Name { get; set; }
        public string UserName { get; set; }

        public string Company { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Description { get; set; }

        public string Website { get; set; }

        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }


        public ApplicationUser User { get; set; }


    }
}