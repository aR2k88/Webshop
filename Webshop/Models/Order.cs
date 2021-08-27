using System;

namespace Webshop.Models
{
    public class Order
    {
        public Guid _id { get; set; }
        public Cart Cart { get; set; }
        public int OrderNumber { get; set; }
    }
}