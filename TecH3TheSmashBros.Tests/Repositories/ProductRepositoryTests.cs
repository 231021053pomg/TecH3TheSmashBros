using System;
using Xunit;
using TecH3TheSmashBros.API.Repositories;
using TecH3TheSmashBros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TecH3TheSmashBros.API.Database;

namespace TecH3TheSmashBros.Tests
{
    public class ProductRepositoryTests
    {
        private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
        private readonly TecH3TheSmashBrosDbContext _context;

        public ProductRepositoryTests() {

            _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductsDatabase")
                .Options;
            _context = new TecH3TheSmashBrosDbContext(_options);

            _context.Database.EnsureDeleted();

            _context.Product.Add(new Product
            {
                Title = "product",
                Storage = 100,
                CategoryId = 1,
                Price = 100

            });
            _context.Product.Add(new Product
            {
                Title = "product2",
                Storage = 40,
                CategoryId = 2,
                Price = 100

            });
            _context.Product.Add(new Product
            {
                Title = "product3",
                Storage = 50,
                CategoryId = 2,
                Price = 70

            });
            _context.SaveChanges();
        }

        [Fact]
        public async void GetAllProducts()
        {
            //arrange
            ProductRepository productRepository = new ProductRepository(_context);
            //act
            var products = await productRepository.GetAllProducts();
            //assert
            Assert.NotNull(products);
            Assert.Equal(3, products.Count);
        }

        [Fact]
        public async void GetProductById()
        {
            //arrange
            ProductRepository productRepository = new ProductRepository(_context);
            //act
            var product = await productRepository.GetProductById(2);
            //assert
            Assert.NotNull(product);
            Assert.Equal("product2", product.Title);
        }

        [Fact]
        public async void GetAllProductsByCategory()
        {
            //arrange
            ProductRepository productRepository = new ProductRepository(_context);
            var categoryId = 2;
            //act
            var products = await productRepository.GetProductsByCategory(categoryId);
            //assert
            Assert.NotNull(products);
            Assert.Equal(2, products.Count);
            Assert.Equal(categoryId, products[0].CategoryId);
        }

        [Fact]
        public async void CreateProduct()
        {
            //arrange
            ProductRepository productRepository = new ProductRepository(_context);
            var _product = new Product
            {
                Title = "new product",
                Storage = 50,
                CategoryId = 4,
                Price = 70

            };

            //act
            var product = await productRepository.CreateProduct(_product);
            var products = await productRepository.GetAllProducts();

            //assert
            Assert.NotNull(product);
            Assert.True(products.Count > 3);
            Assert.Equal(_product, product);
        }

        [Fact]
        public async void UpdateProduct()
        {
            //arrange
            ProductRepository productRepository = new ProductRepository(_context);
            var _product = new Product
            {
                Title = "updated product",
                Storage = 50,
                CategoryId = 4,
                Price = 70

            };

            var productId = 1;
            var oldProduct = await productRepository.GetProductById(productId);

            //act
            var product = await productRepository.UpdateProduct(productId,_product);

            //assert
            Assert.NotNull(product);
            Assert.NotEqual(oldProduct,product);
        }

        [Fact]
        public async void DeleteProduct()
        {
            //arrange
            ProductRepository productRepository = new ProductRepository(_context);

            var productId = 1;

            //act
            var product = await productRepository.DeleteProduct(productId);

            //assert
            Assert.NotNull(product);
            Assert.NotNull(product.DeletedAt);
        }

        [Fact]
        public async void GetImagesByProductId()
        {
            //Tilføjer her senere når jeg laver Image Repo

            //arrange

            //act

            //assert

        }
    }
}
