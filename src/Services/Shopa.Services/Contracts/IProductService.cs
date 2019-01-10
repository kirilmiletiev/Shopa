using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopa.Data.Migrations;
using Shopa.Data.Models;
using Shopa.Data.Models.Enums;

namespace Shopa.Services.Contracts
{
    public interface IProductService
    {
        string CategoryName(Product product);
        Task<List<Product>> GetAllProductsAsync();
        List<Product> GetAllProductsOrderById();
        Product GetProductById(int? id);
        Product GetProductById(int id);
        Product GetRandomProduct();
        Product AddProduct(Product product);
        void SaveChanges();
        void Update(Product product);
        void Remove(Product product);
        bool ProductExists(int id);
        Task<List<Product>> GetAllProductsByCategories(Category category);
        bool IsProductInFavorites(int productId, string userId);
        void AddFavorite(Favorite favorite);
        void RemoveFavorite(Favorite favorite);
        void AddOrder(Order order);
        DbSet<Favorite> GetAllFavorites();
        List<Favorite> GetMyFavorites(string userId);
        string FixLocalPath(string path);
        Favorite GetFavorite(int productId, string userId);
        bool IsActive(int productId, string userId);

    }
}