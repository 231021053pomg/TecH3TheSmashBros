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
            var editProduct = await _sut.Product.FirstOrDefaultAsync(a => a.Id == id);
            if (editProduct != null)
            {
                editProduct = product;
                editProduct.UpdatedAt = DateTime.Now;
                _sut.Product.Update(editProduct);
                await _sut.SaveChangesAsync();
            }
            return editProduct;
        }
    }
}
