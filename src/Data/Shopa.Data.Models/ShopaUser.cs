using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Shopa.Data.Models
{
    // Add profile data for application users by adding properties to the ShopaUser class
    public class ShopaUser : IdentityUser
    {
        public ShopaUser()
        {
            this.Products = new List<Product>();
        }

        public ICollection<Product> Products { get; set; }

        //public Product Product { get; set; }


    }
}
