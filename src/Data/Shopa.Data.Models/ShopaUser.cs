using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    // Add profile data for application users by adding properties to the ShopaUser class
    public class ShopaUser : IdentityUser
    {
        public ShopaUser()
        {
            this.Products = new List<Product>();
            this.Orders = new List<Order>();
            this.Reviews = new List<Review>();
            this.DateOfRegistration = DateTime.UtcNow;
            this.Favorites = new List<Favorite>();
        }

        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Order> Orders { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Favorite> Favorites { get; set; }


        public string PicturePath { get; set; }


    }
}
