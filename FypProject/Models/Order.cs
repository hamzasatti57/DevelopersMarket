using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FypProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(160)]
        public string LastName { get; set; }

        [Display(Name = "Company Name")]
        [StringLength(70, MinimumLength = 3)]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(70, MinimumLength = 3)]
        public string Address { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(70, MinimumLength = 3)]
        public string Addres { get; set; }

        [Required]
        [StringLength(40)]
        public string City { get; set; }

        [Required]
        [StringLength(40)]
        public string State { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(40)]
        public string Country { get; set; }

        [Required]
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Modify:")]
        public modify Modify { get; set; }


        [Required]
        //[RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$",
        //    ErrorMessage = "Card Number is not valid.")]
        public string CardNumber { get; set; }

        [Required]
        //[RegularExpression(@"/^[0-9]{3,4}$/",
        //    ErrorMessage = "CVV Number is is not valid.")]

        public string Cvv { get; set; }

        [Required]
        [Display(Name = "Expiration(MM/YYYY)")]
        public string Year { get; set; }

        

    }
    public enum modify {
        Yes, 
        No
    }
}