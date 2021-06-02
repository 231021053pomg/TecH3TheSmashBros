using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetProductsByCategory(int categoryId);

        Task<Product> GetProductById(int id);

        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(int id, Product product);

        Task<Product> DeleteProduct(int id);

    }
}
