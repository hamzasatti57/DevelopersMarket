using FypProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FypProject.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<CartItem> Items { get; set; }
        public decimal Total { get; set; }
    }
}