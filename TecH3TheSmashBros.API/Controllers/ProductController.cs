﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Services;

namespace TecH3TheSmashBros.API.Controllers
{
    [ApiController]
    [Route("api/")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("products/{categoryId}")]
        public async Task<IActionResult> GetAllProductsByCategory([FromRoute] int categoryId)
        {
            try
            {
                var products = await _productService.GetAllProductsByCategory(categoryId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            try
            {
                var product = await _productService.GetProductById(productId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost("products/{categoryId}")]
        public async Task<IActionResult> CreateProduct([FromRoute] int categoryId, Product product)
        {
            try
            {
                var new_product = await _productService.CreateProduct(product, categoryId);
                return Ok(new_product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPatch("products/{productsId}/{categoryId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productsId, [FromRoute] int categoryId, Product product)
        {
            try
            {
                var removed_product = await _productService.UpdateProduct(productsId, product, categoryId);
                return Ok(removed_product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete("products/{categoryId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int products_id)
        {
            try
            {
                var removed_product = await _productService.DeleteProduct(products_id);
                return Ok(removed_product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet("Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _productService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory(string categoryTitle)
        {
            try
            {
                var new_category = await _productService.CreateCategory(new Category { Title = categoryTitle });
                return Ok(new_category);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete("categories/{categoryId}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
        {
            try
            {
                var removed_category = await _productService.DeleteCategory(categoryId);
                return Ok(removed_category);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
