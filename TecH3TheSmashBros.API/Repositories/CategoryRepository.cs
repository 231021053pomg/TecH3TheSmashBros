using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TecH3TheSmashBrosDbContext _sut;
        public CategoryRepository(TecH3TheSmashBrosDbContext sut)
        {
            _sut = sut;

        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _sut.Category
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }


        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var editcategory = await _sut.Category.FirstOrDefaultAsync(a => a.Id == id);
            if (editcategory != null)
            {
                editcategory.UpdatedAt = DateTime.Now;
                editcategory.Title = category.Title;
                _sut.Category.Update(editcategory);
                await _sut.SaveChangesAsync();
            }
            return editcategory;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            category.CreatedAt = DateTime.Now;
            _sut.Category.Add(category);
            await _sut.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCatagory(int id)
        {
            var category = await _sut.Category.FirstOrDefaultAsync(a => a.Id == id);
            if (category != null)
            {
                category.DeletedAt = DateTime.Now;
                await _sut.SaveChangesAsync();
            }
            return category;
        }

    }
}
