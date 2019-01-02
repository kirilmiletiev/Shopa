using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.TimeOfCreation = DateTime.UtcNow;
            this.Reviews = new List<Review>();
        }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ShopaUser User { get; set; }

        public DateTime TimeOfCreation { get; set; }

        public string PictureLocalPath { get; set; }

        public Store Store { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
