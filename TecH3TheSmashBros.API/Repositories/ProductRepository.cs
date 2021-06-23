using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TecH3TheSmashBrosDbContext _sut;

        public ProductRepository(TecH3TheSmashBrosDbContext sut)
        {
            _sut = sut;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.CreatedAt = DateTime.Now;
            _sut.Product.Add(product);
            await _sut.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _sut.Product
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (product != null)
            {
                product.DeletedAt = DateTime.Now;
                await _sut.SaveChangesAsync();
            }
            return product;
        }

        public async Task<List<Product>> DeleteProductByCategoryId(int categoryId)
        {
            var products = new List<Product> { };

            products = await _sut.Product
                .Where(a => a.DeletedAt == null && a.CategoryId == categoryId)
                .ToListAsync();

            if (products != null)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    products[i].DeletedAt = DateTime.Now;
                }
                await _sut.SaveChangesAsync();
            }
            return products;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _sut.Product
                .Where(a => a.DeletedAt == null)
                .Include(a => a.Category)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _sut.Product
                .Where(a => a.DeletedAt == null)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _sut.Product
                .Where(a => a.DeletedAt == null && a.CategoryId == categoryId)
                .Include(a => a.Category)
                .ToListAsync();
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            Console.WriteLine("repo");
            var editProduct = await _sut.Product.FirstOrDefaultAsync(a => a.Id == id);
            if (editProduct != null)
            {
                editProduct.Title = product.Title;
                editProduct.Price = product.Price;
                editProduct.Storage = product.Storage;
                editProduct.CategoryId = product.CategoryId;
                editProduct.Images = product.Images;

                editProduct.UpdatedAt = DateTime.Now;

                Console.WriteLine(editProduct.CategoryId);
                await _sut.SaveChangesAsync();
            }
            return editProduct;
        }
    }
}
