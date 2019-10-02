using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProducttName { get; set; }

        public string ProductCategory { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }
    }
}