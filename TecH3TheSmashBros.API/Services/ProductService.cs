using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;

namespace TecH3TheSmashBros.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public Task<List<Product>> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Task<List<Product>> GetAllProductsByCategory(int categoryId)
        {
            return _productRepository.GetProductsByCategory(categoryId);
        }

        public Task<Product> GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Task<Product> CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Task<Product> UpdateProduct(int id, Product product)
        {
            return _productRepository.UpdateProduct()
        }

        public Task<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteCategory()
        {
            throw new NotImplementedException();
        }
    }
}