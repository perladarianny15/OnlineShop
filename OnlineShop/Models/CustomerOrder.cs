using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderID { get; set; }

        public string OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public int Product_id { get; set; }

        public int CustomerID { get; set; }
    }
}