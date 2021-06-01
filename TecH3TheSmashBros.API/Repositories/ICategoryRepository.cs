using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory();
    }
}
