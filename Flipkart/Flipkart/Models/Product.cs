using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flipkart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}