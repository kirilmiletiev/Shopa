using System;
using System.Collections.Generic;
using System.Text;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.Products = new List<Product>();
            this.Status = OrderStatus.Pending;
        }

        public decimal TotalPrice { get; set; } 

        public ICollection<Product> Products { get; set; }

        public ShopaUser User { get; set; }

        public OrderStatus Status { get; set; }

        public Store Store { get; set; }    

    }
}
