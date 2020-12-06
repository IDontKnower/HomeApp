using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dawn;
using HomeApp.WebApi.Contexts;
using HomeApp.WebApi.Contexts.ShoppingList;
using HomeApp.WebApi.DTO.ShoppingList;
using HomeApp.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HomeApp.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController: ControllerBase
    {
        private readonly HomeAppContext _homeAppContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ShoppingListController(HomeAppContext homeAppContext, ILogger logger, IMapper mapper)
        {
            Guard.Argument(homeAppContext, nameof(homeAppContext)).NotNull();
            Guard.Argument(logger, nameof(logger)).NotNull();
            Guard.Argument(mapper, nameof(mapper)).NotNull();
            
            _homeAppContext = homeAppContext;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProductsWithCategories()
        {
            try
            {
                var items = await _homeAppContext.Products
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .ToListAsync();
                var convertedItems = _mapper.Map<IEnumerable<ProductCategory>>(items);
                return Ok(convertedItems);
            }    
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(GetProductsWithCategories));
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> CreateProduct(ProductCategory product)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var productConverted = _mapper.Map<Product>(product);
                await _homeAppContext.AddAsync(productConverted);
                await _homeAppContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(CreateProduct));
                return StatusCode(500, e);
            }
        }

        [HttpPatch]
        [Route("products")]
        public async Task<IActionResult> UpdateProduct(ProductCategory product)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var productConverted = _mapper.Map<Product>(product);
                _homeAppContext.Update(productConverted);
                await _homeAppContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(UpdateProduct));
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        [Route("products")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);
                var entity = await _homeAppContext.Products.SingleOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    return NotFound();
                }
                    
                _homeAppContext.Remove(entity);
                await _homeAppContext.SaveChangesAsync();
                return Ok();

            }
            
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(DeleteProduct));
                return StatusCode(500, e);
            }
        }
        
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _homeAppContext.Categories.ToListAsync();
                return Ok(categories);
            }
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(GetCategories));
                return StatusCode(500, e);
            }
        }
        
        [HttpPost]
        [Route("categories")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _homeAppContext.Add(category);
                await _homeAppContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(CreateCategory));
                return StatusCode(500, e);
            }
        }
        
        
        [HttpPatch]
        [Route("categories")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _homeAppContext.Update(category);
                await _homeAppContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(UpdateCategory));
                return StatusCode(500, e);
            }
        }
        
        [HttpDelete]
        [Route("categories")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var entity = await _homeAppContext.Categories
                    .SingleOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    return NotFound();
                }

                _homeAppContext.Remove(entity);
                await _homeAppContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                _logger.Error(e, MessageHelper.ErrorMethodMessage, nameof(DeleteCategory));
                return StatusCode(500, e);
            }
        }
    }
}