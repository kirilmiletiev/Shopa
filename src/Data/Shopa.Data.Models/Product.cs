using System;
using System.Collections.Generic;
using System.Text;

namespace Shopa.Data.Models
{
    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.TimeOfCreation = DateTime.UtcNow;
        }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ShopaUser User { get; set; }

        public DateTime TimeOfCreation { get; set; }
    }
}
