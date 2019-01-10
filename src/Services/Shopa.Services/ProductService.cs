using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shopa.Data;
using Shopa.Data.Models;
using Shopa.Data.Models.Enums;
using Shopa.Services.Contracts;

namespace Shopa.Services
{
    public class ProductService : IProductService
    {
        private ShopaDbContext _context;
        private UserManager<ShopaUser> _userManager;

        public ProductService(ShopaDbContext context, UserManager<ShopaUser> userManager)
        {
            this._context = context;
            _userManager = userManager;
        }

        public List<Product> GetAllProductsOrderById()
        {
            var products = _context.Products.OrderBy(x => x.Id).ToList();
            return products;
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            return _context.Products.ToListAsync();
        }

        public Product GetProductById(int? id)
        {
            var isValid = _context.Products.Any(x => x.Id == id);

            if (isValid)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);
                return product;
            }
            else
            {
                return null;
            }
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetRandomProduct()
        {
            Random rnd = new Random();

            // First product that I seed in database was a test product and he is deleted, but Id from IDENTITY start from 2... therefore is this "Magic number 2" :)
            int productId = rnd.Next(2, _context.Products.Count() + 2);


            Product product = GetProductById(productId);
            return product;
        }

        public Product AddProduct(Product product)
        {
            //var path = product.PictureLocalPath;

            //path = path.Replace('\\', '/');
            //string result = "";
            //var count = 0;

            //string str = "";

            //for (int i = path.Length - 1; i >= 0; i--)
            //{
            //    if (path[i].Equals('/'))
            //    {
            //        count++;
            //    }

            //    if (count == 2)
            //    {
            //        break;
            //    }

            //    str += (path[i]);
            //}

            //result = Reverse(str);
            //result.Replace('/', '\\');

            product.PictureLocalPath = FixLocalPath(product.PictureLocalPath);

            _context.Products.Add(product);

            _context.SaveChangesAsync();
            return product;
        }

        public void SaveChanges()
        {
            _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public string CategoryName(Product product)
        {
            return product.Category.ToString();
        }

        private static string Reverse(string result)
        {
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);

        }

        public Task<List<Product>> GetAllProductsByCategories(Category category)
        {
            return _context.Products.Where(x => x.Category == category).ToListAsync();
        }


        public bool IsProductInFavorites(int productId, string userId)
        {
            return _context.Favorites.Any(x => x.Product.Id == productId && x.ShopaUserId == userId);
        }

        public void AddFavorite(Favorite favorite)
        {
            favorite.IsActive = true;
            _context.Favorites.Add(favorite);
        }

        public void RemoveFavorite(Favorite favorite)
        {
            //_context.Favorites.Select(x => x.IsActive == false);

            favorite.IsActive = false;

            _context.Favorites.Update(favorite);
            //_context.Favorites.Remove(favorite);
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public DbSet<Favorite> GetAllFavorites()
        {
            return _context.Favorites;
        }

        public List<Favorite> GetMyFavorites(string userId)
        {
            return _context.Favorites.Where(x => x.ShopaUserId == userId).ToList();
        }

        bool IProductService.ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public string FixLocalPath(string path)
        {
            path = path.Replace('\\', '/');
            string result = "";
            var count = 0;

            string str = "";

            for (int i = path.Length - 1; i >= 0; i--)
            {
                if (path[i].Equals('/'))
                {
                    count++;
                }

                if (count == 2)
                {
                    break;
                }

                str += (path[i]);
            }

            result = Reverse(str);
            result.Replace('/', '\\');
            return result;
        }

        public Favorite GetFavorite(int productId, string userId)
        {
            var isValid = _context.Favorites.Any(x => x.ProductId == productId && x.ShopaUserId == userId);
            if (isValid)
            {
                return _context.Favorites.FirstOrDefault(x => x.ProductId == productId && x.ShopaUserId == userId);
            }
            else
            {
                return null;
            }
        }

        public bool IsActive(int productId, string userId)
        {
            // Must call first  {GetFavorite} whenever it will be used
            var favorite = this.GetFavorite(productId, userId);

            return favorite.IsActive;

        }
    }
}