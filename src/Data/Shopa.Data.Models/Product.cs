using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.Products = new List<OrderProduct>();
            this.IsActual = true;
            this.AdminApproved = false;
            this.Favorites = new List<Favorite>();
            //this.NumberOfOrderedItems = Numbers.One;
        }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ShopaUser User { get; set; }


        public DateTime TimeOfCreation { get; set; }


        public string PictureLocalPath { get; set; }

        public int? StoreId { get; set; }

        public ICollection<OrderProduct> Products { get; set; }


        public ICollection<Review> Reviews { get; set; }

        [Required]
        public Category Category { get; set; }


        private bool IsActual { get; set; }


        private bool AdminApproved { get; set; }

        public ICollection<Favorite> Favorites { get; set; }

        //public Numbers NumberOfOrderedItems { get; set; }
    }
}
