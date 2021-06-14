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
                Price = 100,
                Images = "img1.png,img2.png"

            });
            _context.Product.Add(new Product
            {
                Title = "product2",
                Storage = 40,
                CategoryId = 1,
                Price = 100,
                Images = "img2.png,img3.png"

            });
            _context.Product.Add(new Product
            {
                Title = "product3",
                Storage = 50,
                CategoryId = 2,
                Price = 70,
                Images = "img4.png,img5.png"

            });
            _context.Category.Add(new Category
            {
                Title = "Category1"
            });
            _context.Category.Add(new Category
            {
                Title = "Category2"
            });
            _context.SaveChanges();
        }

        [Fact]
        public async void GetAllProducts()
        {
            //arrange
            ProductRepository productRepository = new(_context);
            CategoryRepository categoryRepository = new(_context);
            //act
            var products = await productRepository.GetAllProducts();
            var categories = await categoryRepository.GetAllCategories();
            //assert
            Assert.NotNull(products);
            Assert.Equal(3, products.Count);
            Assert.Equal(products[0].CategoryId, categories[0].Id);
        }

        [Fact]
        public async void GetProductById()
        {
            //arrange
            ProductRepository productRepository = new(_context);
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
            ProductRepository productRepository = new(_context);
            var categoryId = 2;
            //act
            var products = await productRepository.GetProductsByCategory(categoryId);
            //assert
            Assert.NotNull(products);
            Assert.Single(products);
            Assert.Equal(2, products[0].CategoryId);
            Assert.Equal("product3", products[0].Title);
        }

        [Fact]
        public async void CreateProduct()
        {
            //arrange
            ProductRepository productRepository = new(_context);
            var new_product = new Product
            {
                Title = "new product",
                Storage = 50,
                CategoryId = 4,
                Price = 70,
                Images = "new_image.jpeg"
            };

            //act
            var products = await productRepository.GetAllProducts();
            var product = await productRepository.CreateProduct(new_product);

            //assert
            Assert.NotNull(product);
            Assert.NotEqual(product.CreatedAt, DateTime.MinValue);
            Assert.Equal(products.Count + 1, product.Id);
        }

        [Fact]
        public async void UpdateProduct()
        {
            //arrange
            ProductRepository productRepository = new(_context);
            var _product = new Product
            {
                Title = "updated product",
                Storage = 50,
                CategoryId = 4,
                Price = 70,
                Images = "new_image.jpeg"

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
            ProductRepository productRepository = new(_context);

            var productId = 1;

            //act
            var product = await productRepository.DeleteProduct(productId);

            //assert
            Assert.NotNull(product);
            Assert.NotNull(product.DeletedAt);
        }
    }
}
