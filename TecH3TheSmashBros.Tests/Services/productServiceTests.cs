using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;
using TecH3TheSmashBros.API.Services;
using Xunit;

namespace TecH3TheSmashBros.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly ProductService productService;
        private readonly Mock<IProductRepository> productRepositoryMock = new();
        private readonly Mock<ICategoryRepository> categoryRepositoryMock = new();

        public ProductServiceTests()
        {
            productService = new ProductService(
                productRepositoryMock.Object,
                categoryRepositoryMock.Object
            );
        }

        [Fact]
        public async Task GetAllProducts()
        {
            //arrange
            productRepositoryMock
                .Setup(x => x.GetAllProducts())
                .ReturnsAsync(() => new List<Product> { new Product(), new Product() });
            //act
            var products = await productService.GetAllProducts();

            //assert
            Assert.NotNull(products);
            Assert.Equal(2, products.Count);
        }

        [Fact]
        public async Task GetAllProductsByCategory()
        {
            //arrange
            productRepositoryMock
                .Setup(x => x.GetProductsByCategory(It.IsAny<int>()))
                .ReturnsAsync(() => new List<Product> { new Product(), new Product() });
            //action
            var products = await productService.GetAllProductsByCategory(0);

            //assert
            Assert.NotNull(products);
            Assert.Equal(2, products.Count);
        }

        [Fact]
        public async Task GetProductById()
        {
            //arrange
            productRepositoryMock
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(() => new Product());
            //action
            var product = await productService.GetProductById(0);

            //assert
            Assert.NotNull(product);
        }
        [Fact]
        public async Task CreateProduct()
        {
            //arrange
            productRepositoryMock
                .Setup(x => x.CreateProduct(It.IsAny<Product>()))
                .ReturnsAsync(() => new Product());
            //action
            var product = await productService.CreateProduct(new Product(),new Category());

            //assert
            Assert.NotNull(product);
        }
        [Fact]
        public async Task UpdateProduct()
        {
            //arrange
            productRepositoryMock
                .Setup(x => x.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .ReturnsAsync(() => new Product());
            //action
            var product = await productService.UpdateProduct(0, new Product(), new Category());
            //assert
            Assert.NotNull(product);
        }
        [Fact]
        public async Task DeleteProduct()
        {
            //arrange
            productRepositoryMock
                .Setup(x => x.DeleteProduct(It.IsAny<int>()))
                .ReturnsAsync(() => new Product());
            //action
            var product = await productService.DeleteProduct(0);
            //assert
            Assert.NotNull(product);
        }
        [Fact]
        public async Task GetAllCategories()
        {
            //arrange
            categoryRepositoryMock
                .Setup(x => x.GetAllCategories())
                .ReturnsAsync(() => new List<Category>());
            //action
            var products = await productService.GetAllCategories();
            //assert
            Assert.NotNull(products);
        }
        [Fact]
        public async Task CreateCategory()
        {
            //arrange
            categoryRepositoryMock
                .Setup(x => x.CreateCategory(It.IsAny<Category>()))
                .ReturnsAsync(() => new Category());
            //action
            var product = await productService.CreateCategory(new Category());
            //assert
            Assert.NotNull(product);
        }
        [Fact]
        public async Task DeleteCategory()
        {
            //arrange
            categoryRepositoryMock
                .Setup(x => x.DeleteCatagory(It.IsAny<int>()))
                .ReturnsAsync(() => new Category());
            //action
            var product = await productService.DeleteCategory(0);
            //assert
            Assert.NotNull(product);
        }
    }
}
