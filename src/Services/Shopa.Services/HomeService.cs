using System;
using System.Collections.Generic;
using System.Linq;
using Shopa.Data;
using Shopa.Data.Models;
using Shopa.Services.Contracts;

namespace Shopa.Services
{
    public class HomeService : IHomeService
    {
        private ShopaDbContext context;

        public HomeService(ShopaDbContext context)
        {
            this.context = context;
        }


        public List<Product> GetAllProducts()
        {
            var products = context.Products.OrderBy(x => x.Id).ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            if (id >= 0)
            {

                var product = context.Products.FirstOrDefault(x => x.Id == id);
                return product;

            }
            else
            {
                return null;
            }
        }

        public ShopaUser GetUserByPhone(string phoneNumber)
        {

            if (phoneNumber != null)
            {
                var user = context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);

                return user;
            }
            else
            {
                return null;
            }
        }

        public Product GetRandomProduct()
        {
            Random rnd = new Random();
            List<int> failsIdProducts = new List<int>() {0,1,12,15,16,18,20,21,23};

            int productId = rnd.Next(1, context.Products.Count() + failsIdProducts.Count);

            while (true)
            {
                if (failsIdProducts.Any(x => x.Equals(productId)))
                {
                    productId = rnd.Next(1, context.Products.Count() + failsIdProducts.Count);
                }
                else
                {
                    break;
                }
            }

            Product product = GetProductById(productId);
            return product;
        }

        public string CategoryName(Product product)
        {
            return product.Category.ToString();
        }
    }
}
