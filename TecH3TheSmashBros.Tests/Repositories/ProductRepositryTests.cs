using System;
using Xunit;
using TecH3TheSmashBros.API.Repositories;
using TecH3TheSmashBros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TecH3TheSmashBros.API.Database;

namespace TecH3TheSmashBros.Tests
{
    public class ProductRepositryTests
    {

        private readonly DbContextOptions<TecH3TheSmashBrosDbContext> _options;
        private readonly TecH3TheSmashBrosDbContext _context;

        [Fact]
        public void GetAllProducts()
        {
        
        }
    }
}
