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

        public Task<Product> CreateProduct(Product product, Category category)
        {
            product.CategoryId = category.Id;
            return _productRepository.CreateProduct(product);
        }

        public Task<Product> UpdateProduct(int id, Product product, Category category)
        {
            product.CategoryId = category.Id;
            return _productRepository.UpdateProduct(id, product);
        }

        public Task<Product> DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public Task<List<Category>> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Task<Category> CreateCategory(Category category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        public Task<Category> DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCatagory(id);
        }
    }
}