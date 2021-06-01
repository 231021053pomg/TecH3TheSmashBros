using System;
using Xunit;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using Microsoft.EntityFrameworkCore;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Repositories;

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

            _context = new TecH3TheSmashBrosDbContext(_options);

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
        public async Task GetAllCategoriesById()
        {
            // Arange
            CategoryRepository categoryRepository = new CategoryRepository(_context);

            // act
            var category = await categoryRepository.GetAllCategories();

            // Assert
            Assert.NotNull(category);
            Assert.Equal(3, category.Count);
        }
    }
}
