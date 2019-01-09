using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopa.Data.Models
{
    public class OrderProduct : BaseModel<int>
    {
        public OrderProduct()
        {
            this.Quantity = 0;
        }

        [Required]
        public int Quantity { get; set; }
        
        //public Order Order { get; set; }
        
        public Product Product { get; set; }
    }
}
