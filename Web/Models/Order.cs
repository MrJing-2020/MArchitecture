using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public string customerName { get; set; }
        public string shipperCity { get; set; }
    }
}