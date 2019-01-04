using System;
using System.Collections.Generic;
using System.Text;
using Shopa.Data.Models.Enums;

namespace Shopa.Data.Models
{
    public class Store : BaseModel<int>
    {
        //TODO : Promotions of some of products
        //public Store(Dictionary<Product, int> quantity, List<Order> orders)
        //{
        //    Quantity = quantity;
        //    Orders = orders;
        //}

        public Store()
        {
            Products = new List<Product>();
            this.Quantity = new List<Quantity>();
            this.Orders = new List<Order>();
            this.Users = new List<ShopaUser>();
        }

        //public Store(
        //    ICollection<Quantity> quantity,
        //    ICollection<Product> products, 
        //    ICollection<Order> orders,
        //    ICollection<ShopaUser> users, 
        //    Balance balance)
        //{
        //    Product testProduct = new Product(){Category = Categories.AutoProducts, Description = "Dildo", Price = 5, PictureLocalPath = "images/nike-hyper.jpg" };

        //    Quantity = new List<Quantity>();
        //    Products = new List<Product>();
        //    Orders = new List<Order>();
        //    Users = new List<ShopaUser>();
        //    Balance = balance;

        //    this.Products.Add(testProduct);
        //}
        
        //public IDictionary<Product, int> Quantity { get; set; }
        public ICollection<Quantity> Quantity { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<ShopaUser> Users { get; set; }

        public Balance Balance { get; set; }
    }
}
