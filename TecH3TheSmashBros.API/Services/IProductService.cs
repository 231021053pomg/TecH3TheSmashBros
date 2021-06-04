using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetAllProductsByCategory(int categoryId);

        Task<Product> GetProductById(int id);

        Task<Product> CreateProduct(Product product);
    }
}
