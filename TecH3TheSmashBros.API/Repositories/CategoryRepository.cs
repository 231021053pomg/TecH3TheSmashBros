using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;

namespace TecH3TheSmashBros.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategory()
        {
            throw new NotImplementedException();
        }
    }
}
