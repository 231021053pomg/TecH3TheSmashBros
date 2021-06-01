using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    interface IProductRepository
    {
        Task<List<User>> GetAllProducts();

        Task<List<User>> GetProductsByCategory(Category category);

        Task<User> GetProductById(int id);

        Task<User> CreateProduct(Product product);

        Task<User> UpdateProduct(int id, Product product);

        Task<User> DeleteProduct(int id);

    }
}
