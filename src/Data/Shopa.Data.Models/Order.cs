using System;
using System.Collections.Generic;
using System.Text;

namespace Shopa.Data.Models
{
    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.Products = new List<Product>();
        }

        public decimal TotalPrice { get; set; } 

        public ICollection<Product> Products { get; set; }

        public ShopaUser User { get; set; }

    }
}
