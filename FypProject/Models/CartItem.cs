using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FypProject.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public string CartId { get; set; }

        public int GraphicID { get; set; }

        public int Count { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        public virtual Graphic Product { get; set; }
    }
}