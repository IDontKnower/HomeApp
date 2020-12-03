using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeApp.WebApi.Contexts.ShoppingList;
using Microsoft.AspNetCore.Mvc;

namespace HomeApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController: ControllerBase
    {
        public Task<IActionResult> GetProductsWithCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CreateProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}