using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaypalIntegeration.Models
{
    public class Product
    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
    }
}