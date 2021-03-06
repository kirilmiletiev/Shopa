﻿using System;
using System.Collections.Generic;
using System.Text;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Store : BaseModel<int>
    {
        //TODO : Promotions of some of products

        public Store()
        {
            Products = new List<Product>();
            this.Quantity = new List<Quantity>();
            this.Orders = new List<Order>();
            this.Users = new List<ShopaUser>();
        }
        
        public ICollection<Quantity> Quantity { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<ShopaUser> Users { get; set; }

        public Balance Balance { get; set; }
    }
}
