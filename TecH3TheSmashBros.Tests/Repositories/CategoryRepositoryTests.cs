using System;
using Xunit;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using Microsoft.EntityFrameworkCore;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;
using System.Collections.Generic;

namespace TecH3TheSmashBros.Tests
{
    public class CategoryRepositoryTests
    {
        private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
        private readonly TecH3TheSmashBrosDbContext _context;

        public CategoryRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                .UseInMemoryDatabase(databaseName: "CategoryDatabase")
                .Options;

            _context = new (_options);

            _context.Database.EnsureDeleted();
            _context.Category.Add(new Category
            {
                Id = 1,
                Title = "Busker"
            });
            _context.Category.Add(new Category
            {
                Id = 2,
                Title = "T-shirt"
            }); _context.Category.Add(new Category
            {
                Id = 3,
                Title = "Sko"
            });
            _context.SaveChanges();

        }
        [Fact]
        public async Task GetAllCategories()
        {
            // Arange
            CategoryRepository categoryRepository = new(_context);

            // act
            var category = await categoryRepository.GetAllCategories();

            // Assert
            Assert.NotNull(category);
            Assert.Equal(3, category.Count);
        }
        [Fact]
        public async Task DeleteId_ShouldDeleteCategory()
        {
            // Arange
            CategoryRepository categoryRepository = new (_context);
            // Act
            int categoryId = 1;
            var category = await categoryRepository.DeleteCatagory(categoryId);
            // Assert
            Assert.NotNull(category);
            Assert.Equal(categoryId, category.Id);
            Assert.Equal("Busker", category.Title);
            Assert.NotNull(category.DeletedAt);
        }
        [Fact]
        public async Task UpdateId_ShouldUpdateCategory()
        {
            // Arange
            CategoryRepository categoryRepository = new(_context);
            int categoryId = 1;
            Category categoryupdate = new()
            {
                Title = "Polo"
            };
            // Act
            var category = await categoryRepository.UpdateCategory(1, categoryupdate);
            // Assert
            Assert.NotNull(category);
            Assert.Equal(categoryId, category.Id);
            Assert.Equal("Polo", category.Title);
            Assert.NotNull(category.UpdatedAt);

        }
        [Fact]
        public async Task Create_shouldcreateCategory()
        {
            // arange
            CategoryRepository categoryRepository = new(_context);
            Category newcategory = new()
            {
                Title = "Ulv trøje"
            };
            List<Category> categories = await categoryRepository.GetAllCategories();

            // act
            var category = await categoryRepository.CreateCategory(newcategory);

            // assert
            Assert.NotNull(category);
            Assert.NotEqual(DateTime.MinValue, category.CreatedAt);
            Assert.Equal(categories.Count + 1, category.Id);
        }

    }
}
