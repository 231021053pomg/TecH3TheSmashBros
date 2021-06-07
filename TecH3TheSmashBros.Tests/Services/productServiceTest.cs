using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Database;

namespace TecH3TheSmashBros.Tests.Services
{_
    public class ProductServiceTest()
    {
        private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
        private readonly TecH3TheSmashBrosDbContext _context;

        public ProductServiceTest()
        {
            _options = new DbContextOptionsBuilder<TecH3TheSmashBrosDbContext>()
                    .UseInMemoryDatabase(databaseName: "Product Database")
                    .Options;
            _context = new TecH3TheSmashBrosDbContext(_options);
            
            _context.Database.EnsureDeleted();
        }
    }

}