using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.Products = new List<OrderProduct>();
            this.Status = OrderStatus.Pending;
            this.TotalPrice = 0;
            this.TimeOfOrder = DateTime.UtcNow;
        }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } 

        public ICollection<OrderProduct> Products { get; set; }

        [Required]
        public string UserId { get; set; }
        public ShopaUser User { get; set; }


        [Required]
        public OrderStatus Status { get; set; }
        
        public int? StoreId { get; set; }

        public DateTime TimeOfOrder { get; set; }
    }
}
