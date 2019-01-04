using System.Collections.Generic;
using Shopa.Data.Models;

namespace Shopa.Web.Services.Contracts
{
    public interface IHomeService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        ShopaUser GetUserByPhone(string phoneNumber);
        Product GetRandomProduct();

        string CategoryName(Product product);
    }
}