using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Quantity : BaseModel<int>
    {
        public Quantity()
        {
            this.Amount = 0;
            this.LastBuyPrice = 0;
        }

        [Required]
        public int Amount { get; set; }

        public Product Product { get; set; }

       
        public int? StoreId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LastBuyPrice { get; set; }

        public QuantityAlert QuantityAlert { get; set; }
    }
}
