using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<Category> UpdateCategory(int id, Category category);
        Task<Category> DeleteCatagory(int id);

    }
}
