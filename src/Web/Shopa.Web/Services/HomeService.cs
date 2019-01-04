using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopa.Data;
using Shopa.Data.Models;
using Shopa.Web.Services.Contracts;

namespace Shopa.Web.Services
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
            if (id >= 0 )
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

            //int productId = rnd.Next(0, context.Products.Count());
            int productId = rnd.Next(22, GetAllProducts().Count + 22);

            Product product = GetProductById(productId);
            return product;
        }

        public string CategoryName(Product product)
        {
            return product.Category.ToString();
        }
    }
}
